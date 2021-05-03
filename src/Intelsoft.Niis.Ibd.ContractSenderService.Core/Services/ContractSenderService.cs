using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Intelsoft.Niis.Ibd.ContractSenderService.Configuration;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Builders;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Exceptions;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Properties;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contract;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Entities.Maps;
using Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor;
using Intelsoft.Niis.Ibd.Shared.Extensions;
using Polly;
using Polly.Retry;
using Serilog;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Services
{
    public class ContractSenderService : IContractSenderService
    {
        private readonly ContractSenderServiceConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly ISoapExecutor _soapExecutor;
        private readonly RetryPolicy _soapRetryPolicy;
        private readonly IUnitOfWork _unitOfWork;

        public ContractSenderService(
            IUnitOfWork unitOfWork,
            ISoapExecutor soapExecutor,
            ContractSenderServiceConfiguration configuration,
            ILogger logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _soapExecutor = soapExecutor ?? throw new ArgumentNullException(nameof(soapExecutor));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _soapRetryPolicy = Policy.Handle<Exception>()
                .WaitAndRetry(_configuration.MaxRetryAttempts, i =>
                    TimeSpan.FromMinutes(_configuration.PauseBetweenFailuresInMinutes));
        }

        /// <inheritdoc cref="IContractSenderService.GetAvailableContracts" />
        public IEnumerable<ContractData> GetAvailableContracts()
        {
            var availableContractIds = _unitOfWork.ContractRepository?.GetAvailableContracts()
                .Select(x => x.ContractId)
                .ToList();

            return _unitOfWork.NiisContractRepository.GetContractEntities(availableContractIds)?.Select(x=>x?.ToDomain()).ToList();
        }

        /// <inheritdoc cref="IContractSenderService.Send" />
        public void Send(ContractData contract)
        {
            if (contract == null)
                throw new ArgumentNullException(nameof(contract));

            if (contract.ContractType == null)
                throw new ContractException(string.Format(Resources.CannotBeNull, nameof(contract.ContractType)));

            if (contract.Property == null)
                throw new ContractException(string.Format(Resources.CannotBeNull, nameof(contract.Property)));

            var contractEntity = _unitOfWork.ContractRepository.GetByIds(contract.ContractId, contract.PropertyId);
            if (contractEntity == null)
            {
                _logger.Warning(string.Format(Resources.NotFoundById, nameof(contractEntity), contract.ContractId));
                return;
            }

            var messageId = Guid.NewGuid().ToString();
            var messageDate = DateTime.Now;
            var messageData = contract.SerializeToString();

            // Собираем запрос для ИБД.
            var request = new SendMessageRequestBuilder()
                .AddMessageId(messageId)
                .AddMessageDate(messageDate)
                .AddServiceId(_configuration.ServiceId)
                .AddSenderId(_configuration.SenderId)
                .AddPassword(_configuration.Password)
                .AddData(messageData)
                .NeedToSignRequest(_configuration.NeedToSignXml)
                .SetEdsPath(_configuration.EdsPath)
                .SetEdsPassword(_configuration.EdsPassword)
                .Build();

            SoapExecutionResponse response = null;
            try
            {
                // Отправляем запрос в ИБД.
                var soapRequest = new SoapExecutionRequest(
                    _configuration.ShepWebAddress,
                    Constants.EgovGateway.Actions.SendMessage,
                    Constants.EgovGateway.Methods.Post,
                    request);

                if (_configuration.UseRetryPolicy)
                    _soapRetryPolicy.Execute(() =>
                        response = _soapExecutor.Execute(soapRequest));
                else
                    response = _soapExecutor.Execute(soapRequest);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, Resources.ErrorSendRequest);
                throw;
            }

            if (response == null)
                throw new InvalidOperationException(string.Format(Resources.CannotBeNull, nameof(response)));

            // Изменяем cтатус отправки на True.
            contractEntity.Dispatch();
            _unitOfWork.ContractRepository.Edit(contractEntity);

            // Сохраняем отправленный запрос в ИБД.
            var requestMessage = new MessageEntity(
                messageId,
                messageDate,
                string.Empty,
                MethodEntity.Request,
                DirectionEntity.Niis,
                DirectionEntity.Ibd,
                request);

            var contractMessageMap = new ContractRequestMessageMapEntity(contractEntity, requestMessage);

            _unitOfWork.MessageRepository.Add(requestMessage);
            _unitOfWork.ContractRequestMessageMapRepository.Add(contractMessageMap);

            // Парсим correlationId из полученного ответа от ШЭП-а.
            var responseDocument = XDocument.Parse(response.Value);
            var responseElement = responseDocument.Descendants().FirstOrDefault(x => x.Name.LocalName == "response");
            var correlationId = (string)responseElement?.Element("correlationId") ?? string.Empty;

            // Сохраняем полученный ответ.
            var responseMessage = new MessageEntity(
                messageId,
                messageDate,
                correlationId,
                MethodEntity.Request,
                DirectionEntity.Ibd,
                DirectionEntity.Niis,
                response.Value);

            _unitOfWork.MessageRepository.Add(responseMessage);

            try
            {
                // Сохраняем изменения.
                _unitOfWork.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, Resources.ErrorUnitOfWorkSaveChanges);
                throw;
            }
        }
    }
}