using System;
using System.Linq;
using System.ServiceModel;
using System.Xml.Linq;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;
using Intelsoft.Niis.Ibd.Shared.Extensions;
using Serilog;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ReceiveStatusService : IReceiveStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ReceiveStatusService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc cref="IReceiveStatusService.SendMessageResponse"/>
        public void SendMessageResponse(string response)
        {
            try
            {
                // Содержит XML запрос.
                // NOTE: Получаем запрос из OperationContext, а не из аргумента метода.
                var rawData = OperationContext.Current.RequestContext.RequestMessage.ToString();

                _logger.Information($"Incomming request: {rawData}");

                if (rawData == null) return;

                // NOTE: Не десериализуем. Не совсем понятно, чего ожидать от ШЭП или ИБД.
                var xmlDocument = XDocument.Parse(rawData);

                var responseInfo = xmlDocument
                    .Descendants()
                    .FirstOrDefault(x => x.Name.LocalName == "responseInfo");

                if (responseInfo == null) return;

                var message = CreateMessage(responseInfo, rawData);

                var data = xmlDocument
                    .Descendants()
                    .FirstOrDefault(x => x.Name.LocalName == "data");

                if (data != null)
                {
                    var ibdResponse = CreateIbdResponse(data);
                    message.AddIdbResponses(ibdResponse);
                }

                _unitOfWork.MessageRepository.Add(message);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.Error(e, nameof(SendMessageResponse));
            }
        }

        private static MessageEntity CreateMessage(XContainer container, string rawData)
        {
            var messageId = (string)container.Element("messageId");
            var messageDate = container.Element("responseDate")?.ToString().Convert(DateTime.Now);
            var correlationId = (string)container.Element("correlationId");

            return new MessageEntity(messageId,
                messageDate,
                correlationId,
                Method.Request,
                Direction.Ibd,
                Direction.Niis,
                rawData);
        }

        private static IbdResponseEntity CreateIbdResponse(XContainer container)
        {
            var responseId = (string)container.Element("IdbResponseId");
            var responseDate = container.Element("IdbResponseDate")?.ToString().Convert(DateTime.Now);
            var errorCode = (string)container.Element("IdbErrorCode");
            var dataProcessingText = (string)container.Element("IdbDataProcessingText");
            var requestId = (string)container.Element("IdbRequestId");

            return new IbdResponseEntity(responseId,
                responseDate,
                errorCode,
                dataProcessingText,
                requestId);
        }
    }
}
