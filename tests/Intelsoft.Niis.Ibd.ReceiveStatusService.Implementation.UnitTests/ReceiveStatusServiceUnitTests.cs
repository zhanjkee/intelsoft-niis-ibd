using System;
using System.ServiceModel;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Entities.Maps;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests;
using Moq;
using Serilog;
using Xunit;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation.UnitTests
{
    public class ReceiveStatusServiceUnitTests
    {
        [Fact]
        public void SendMessage_ShouldSucceed()
        {
            // Arrange.
            var request = GetMessageRequestWithData();
            var receiveStatusService = GetReceiveStatusService();

            // Act.
            receiveStatusService.SendMessage(request);

            // Assert.
            Assert.True(true);
        }

        [Fact]
        public void SendMessage_ShouldFail()
        {
            // Arrange.
            var request = GetMessageRequestWithoutData();
            var receiveStatusService = GetReceiveStatusService();

            // Act & Assert.
            Assert.Throws<FaultException>(() => receiveStatusService.SendMessage(request));
        }

        private ReceiveStatusService GetReceiveStatusService()
        {
            var ibdResponseEntity = new IbdResponseEntity(It.IsAny<string>(), It.IsAny<DateTime?>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>());

            var mockIbdResponseRepository = new Mock<IIbdResponseRepository>();
            mockIbdResponseRepository.Setup(r => r.Add(ibdResponseEntity));

            var messageEntity = new MessageEntity(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                It.IsAny<MethodEntity>(), It.IsAny<DirectionEntity>(), It.IsAny<DirectionEntity>(), It.IsAny<string>());

            var mockMessageRepository = new Mock<IMessageRepository>();
            mockMessageRepository.Setup(r => r.Add(messageEntity));

            var mockIbdResponseMessageMapRepository = new Mock<IIbdResponseMessageMapRepository>();
            mockIbdResponseMessageMapRepository.Setup(r =>
                r.Add(new IbdResponseMessageMapEntity(ibdResponseEntity, messageEntity)));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(x => x.IbdResponseRepository)
                .Returns(mockIbdResponseRepository.Object);
            mockUnitOfWork
                .Setup(x => x.MessageRepository)
                .Returns(mockMessageRepository.Object);
            mockUnitOfWork
                .Setup(x => x.IbdResponseMessageMapRepository)
                .Returns(mockIbdResponseMessageMapRepository.Object);

            return new ReceiveStatusService(mockUnitOfWork.Object, new Mock<ILogger>().Object);
        }

        private static SendMessageRequest GetMessageRequestWithoutData()
        {
            return new SendMessageRequest
            {
                Request = new Request
                {
                    MessageData = new MessageData
                    {
                        Data = new Contract.Requests.Data()
                    },
                    MessageInfo = new MessageInfo
                    {
                        ServiceId = "TEST",
                        CorrelationId = "TEST",
                        MessageDate = DateTime.Now,
                        MessageId = "TEST",
                        MessageType = "TEST",
                        Sender = new Sender
                        {
                            Password = "TEST",
                            SenderId = "TEST",
                            SessionId = "TEST"
                        },
                        SessionId = "TEST"
                    }
                }
            };
        }

        private static SendMessageRequest GetMessageRequestWithData()
        {
            var request = GetMessageRequestWithoutData();
            request.Request.MessageData.Data.IdbDataProcessingResponse = new IdbDataProcessingResponse
            {
                IdbDataProcessingText = "TEST",
                IdbErrorCode = "TEST",
                IdbRequestId = "TEST",
                IdbResponseDate = DateTime.Now,
                IdbResponseId = "TEST"
            };
            return request;
        }
    }
}