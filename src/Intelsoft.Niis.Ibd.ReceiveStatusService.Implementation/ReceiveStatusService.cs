using System;
using System.ServiceModel;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Entities.Maps;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation.Exceptions;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation.Properties;
using JetBrains.Annotations;
using Serilog;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        IncludeExceptionDetailInFaults = true)]
    public class ReceiveStatusService : IReceiveStatusService
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ReceiveStatusService([NotNull] IUnitOfWork unitOfWork, [NotNull] ILogger logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc cref="IReceiveStatusService.SendMessage" />
        public void SendMessage(SendMessageRequest request)
        {
            try
            {
                if (request == null)
                    throw new ArgumentNullException(nameof(request));

                var messageInfo = request.Request?.MessageInfo;
                if (messageInfo == null)
                    throw new MessageInfoException(string.Format(Resources.CannotBeNull, nameof(messageInfo)));

                var idbResponse = request.Request?.MessageData?.Data?.IdbDataProcessingResponse;
                if (idbResponse == null)
                    throw new IbdResponseException(string.Format(Resources.CannotBeNull, nameof(idbResponse)));

                // Получаем сырой запрос из контекста запроса.
                var rawData = OperationContext.Current?.RequestContext?.RequestMessage?.ToString();

                var message = new MessageEntity(messageInfo.MessageId,
                    messageInfo.MessageDate,
                    messageInfo.CorrelationId,
                    MethodEntity.Request,
                    DirectionEntity.Ibd,
                    DirectionEntity.Niis,
                    rawData);

                var ibdData = new IbdResponseEntity(idbResponse.IdbResponseId,
                    idbResponse.IdbResponseDate,
                    idbResponse.IdbErrorCode,
                    idbResponse.IdbDataProcessingText,
                    idbResponse.IdbRequestId);

                var ibdDataMessageMap = new IbdResponseMessageMapEntity(ibdData, message);

                _unitOfWork.MessageRepository.Add(message);
                _unitOfWork.IbdResponseRepository.Add(ibdData);
                _unitOfWork.IbdResponseMessageMapRepository.Add(ibdDataMessageMap);
                _unitOfWork.SaveChanges();
            }
            catch (Exception exception)
            {
                var baseException = exception.GetBaseException();
                _logger.Error(baseException, nameof(SendMessage));
                throw new FaultException(baseException.Message);
            }
        }
    }
}