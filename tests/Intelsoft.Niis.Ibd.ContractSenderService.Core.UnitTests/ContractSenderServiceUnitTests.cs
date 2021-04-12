using System;
using Intelsoft.Niis.Ibd.ContractSenderService.Configuration;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Exceptions;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contract;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Property;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Entities.Maps;
using Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor;
using Moq;
using Serilog;
using Xunit;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.UnitTests
{
    public class ContractSenderServiceUnitTests
    {
        [Fact]
        public void Send_ContractData_ShouldSuccess()
        {
            // Arrange.
            var contractSenderService = GetMockContractSenderService();

            // Act.
            contractSenderService.Send(GetContractDataWithProperty());

            // Assert.
            Assert.True(true);
        }

        [Fact]
        public void Send_ContractData_ShouldFail()
        {
            // Arrange.
            var contractSenderService = GetMockContractSenderService();

            // Act & Assert.
            Assert.Throws<ContractException>(() => contractSenderService.Send(GetContractDataWithoutProperty()));
        }

        private Services.ContractSenderService GetMockContractSenderService()
        {
            var configuration = new ContractSenderServiceConfiguration
            {
                MaxRetryAttempts = 2,
                PauseBetweenFailuresInMinutes = 1,
                UseRetryPolicy = false,
                ServiceId = "IbdNiisActual",
                SenderId = "kazpatent",
                Password = "test",
                NeedToSignXml = false,
                ShepWebAddress = "",
                EdsPassword = "",
                EdsPath = "",
                PauseBetweenCyclesInMinutes = 1
            };

            var contractEntity = new ContractRequestEntity();
            var messageEntity = new MessageEntity(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                It.IsAny<MethodEntity>(), It.IsAny<DirectionEntity>(), It.IsAny<DirectionEntity>(), It.IsAny<string>());

            var mockContractRepository = new Mock<IContractRepository>();
            mockContractRepository.Setup(r => r.Add(contractEntity));
            mockContractRepository.Setup(r => r.GetById(1))
                .Returns(contractEntity);

            var mockMessageRepository = new Mock<IMessageRepository>();
            mockMessageRepository.Setup(r => r.Add(messageEntity));

            var mockContractMessageMapRepository = new Mock<IContractRequestMessageMapRepository>();
            mockContractMessageMapRepository.Setup(r =>
                r.Add(new ContractRequestMessageMapEntity(contractEntity, messageEntity)));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(x => x.ContractRepository)
                .Returns(mockContractRepository.Object);
            mockUnitOfWork
                .Setup(x => x.MessageRepository)
                .Returns(mockMessageRepository.Object);
            mockUnitOfWork
                .Setup(x => x.ContractRequestMessageMapRepository)
                .Returns(mockContractMessageMapRepository.Object);

            return new Services.ContractSenderService(mockUnitOfWork.Object,
                new MockSoapExecutor(), configuration, new Mock<ILogger>().Object);
        }

        private static ContractData GetContractDataWithProperty()
        {
            var contractData = GetContractDataWithoutProperty();
            contractData.Property = new PropertyData
            {
                Name = "TEST",
                ProtectionNumber = "1234",
                RegistrationDate = DateTime.Now,
                Type = PropertyReference.IndustrialDesign,
                ValidityDate = DateTime.Now.AddDays(5)
            };

            return contractData;
        }

        private static ContractData GetContractDataWithoutProperty()
        {
            return new ContractData
            {
                AssigneeName = "TEST",
                AssigneeXin = "123456789012",
                ContractNumber = "12345",
                ContractRegistrationDate = DateTime.Now,
                ContractType = new ContractReference
                {
                    Id = 1,
                    NameKz = "TEST",
                    NameRu = "TEST"
                },
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "TEST",
                UpdatedDate = DateTime.Now,
                Xin = "123456789011"
            };
        }

        private class MockSoapExecutor : ISoapExecutor
        {
            // NOTE: По непонятной мне причине, Mock возвращает null.
            public SoapExecutionResponse Execute(SoapExecutionRequest request)
            {
                return new SoapExecutionResponse(@"<?xml version=""1.0""?>
<message>
    <response>
    	<messageInfo>
    		<messageId>216386080</messageId>
    		<correlationId>3226347</correlationId>
    		<serviceId>IbdNiisActual</serviceId>
    		<messageType>RESPONSE</messageType>
    		<messageDate>2021-02-09T17:26:36</messageDate>
    		<sender>
    			<senderId>ish_kgd</senderId>
    			<password>c38c7a66cc32e61236ce8d1c242bc738ce9073ebd2c815de0d33f31b4d2e2b66</password>
    			<sessionId>0863c160-11fc-4e22-9bf3-f83624feb240</sessionId>
    		</sender>
    		<sessionId>{05705194-3aa4-464b-98c2-f0cffcc10747}</sessionId>
    	</messageInfo>
    </response>
</message>
");
            }
        }
    }
}