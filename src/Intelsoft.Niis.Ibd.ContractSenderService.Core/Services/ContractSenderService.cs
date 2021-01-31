using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Builders;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Infrastructure.Soap;
using Intelsoft.Niis.Ibd.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Services
{
    public class ContractSenderService : IContractSenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly ISoapClient _soapClient;

        public ContractSenderService(IUnitOfWork unitOfWork, ISoapClient soapClient, ILogger logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _soapClient = soapClient ?? throw new ArgumentNullException(nameof(soapClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        /// <inheritdoc cref="IContractSenderService.GetAvailableContracts"/>
        public IEnumerable<ContractRequestEntity> GetAvailableContracts()
        {
            return _unitOfWork?.ContractRepository?.GetAvailableContracts()
                ?.Include(x => x.DispatchStatus)
                ?.Include(x => x.Type)
                ?.Include(x => x.Property)
                ?.ToList();
        }

        /// <inheritdoc cref="IContractSenderService.Send"/>
        public void Send(ContractRequestEntity contract)
        {
            if (contract == null)
                throw new ArgumentNullException(nameof(contract));

            if (contract.Type == null || contract.Property == null || contract.DispatchStatus == null)
                return;

            var messageId = Guid.NewGuid().ToString();
            var messageDate = DateTime.Now;
            // TODO: Вынести в конфиги.
            const string serviceId = "IbdNiisActual";
            const string senderId = "kazpatent";
            const string password = "CY}C@ne$Wo";

            // Сериализуем в xml.
            var contractDomain = contract.ToDomain();
            var contractXml = contractDomain.SerializeToString();

            var request = new SendMessageRequestBuilder()
                .AddMessageId(messageId)
                .AddMessageDate(messageDate)
                .AddServiceId(serviceId)
                .AddSenderId(senderId)
                .AddPassword(password)
                .AddData(contractXml)
                .Build();

            var response = string.Empty;
            try
            {
                // TODO: Использовать Retry policy.
                // Отправляем запрос в ИБД.
                response = _soapClient.Invoke(
                            action: Constants.EgovGateway.Actions.SendMessage,
                            method: Constants.EgovGateway.Methods.Post,
                            requestData: request);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, nameof(SoapClient.Invoke));
            }

            var requestMessage = new MessageEntity(
                messageId,
                messageDate,
                string.Empty,
                MethodEntity.Request,
                DirectionEntity.Niis,
                DirectionEntity.Ibd,
                request);
            requestMessage.AddContractRequests(contract);

            // Из респонс получаем correlationId.
            var responseDocument = XDocument.Parse(response);
            var responseElement = responseDocument.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "response");

            var correlationId = (string)responseElement?.Element("correlationId") ?? string.Empty;

            var responseMessage = new MessageEntity(
                messageId,
                messageDate,
                correlationId,
                MethodEntity.Request,
                DirectionEntity.Ibd,
                DirectionEntity.Niis,
                response);

            // Сохраняем сообщение.
            var messageRepository = _unitOfWork.MessageRepository;
            messageRepository.Add(requestMessage);
            messageRepository.Add(responseMessage);

            contract.Dispatch();

            _unitOfWork.ContractRepository.Edit(contract);

            try
            {
                // TODO: Использовать Retry policy.
                _unitOfWork.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, nameof(IUnitOfWork.SaveChanges));
            }
        }
    }
}
