using System;
using System.ServiceModel;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts;
using Serilog;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single, 
        IncludeExceptionDetailInFaults = true)]
    public class SendMessageResponseService : ISendMessageResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public SendMessageResponseService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc cref="ISendMessageResponseService.SendMessage"/>
        public void SendMessage(SendMessageResponse request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var messageInfo = request.Request?.MessageInfo;
            if (messageInfo == null)
                return;

            var idbResponse = request.Request?.MessageData?.Data?.IdbDataProcessingResponse;
            if (idbResponse == null)
                return;
            
            var message = new MessageEntity(messageInfo.MessageId,
                messageInfo.MessageDate,
                messageInfo.CorrelationId,
                MethodEntity.Request,
                DirectionEntity.Ibd,
                DirectionEntity.Niis,
                string.Empty);

            var ibdData = new IbdResponseEntity(idbResponse.IdbResponseId,
                idbResponse.IdbResponseDate,
                idbResponse.IdbErrorCode,
                idbResponse.IdbDataProcessingText,
                idbResponse.IdbRequestId);

            message.AddIdbResponses(ibdData);

            try
            {
                var messageRepository = _unitOfWork.MessageRepository;
                messageRepository.Add(message);
                _unitOfWork.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, nameof(SendMessage));
            }
        }
    }
}
