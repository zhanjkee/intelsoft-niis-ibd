using System;
using System.Linq;
using Intelsoft.Niis.Ibd.Data.Configuration;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.Tests;
using Intelsoft.Niis.Ibd.Data.UoW;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Xunit;

namespace Intelsoft.Niis.Ibd.Data.UnitTests
{
    public class MessageRepositoryUnitTests
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageRepositoryUnitTests()
        {
            _unitOfWork = new UnitOfWork(new InMemoryDataContextFactory(), new ConnectionStringsConfiguration
            {
                UseRetryPolicy = false,
                ConnectionString = "",
                MaxRetryAttempts = 1,
                PauseBetweenFailuresInMinutes = 1
            });
        }

        [Fact]
        public void AddMessage_ShouldSucceed()
        {
            // Arrange.
            var messageId = Guid.NewGuid().ToString();
            var messageDate = DateTime.Now;
            var correlationId = Guid.NewGuid().ToString();

            // Act.
            _unitOfWork.MessageRepository.Add(new MessageEntity(
                messageId,
                messageDate,
                correlationId,
                MethodEntity.Request,
                DirectionEntity.Ibd,
                DirectionEntity.Niis,
                string.Empty
            ));
            _unitOfWork.SaveChanges();

            var messages = _unitOfWork.MessageRepository.GetAll().ToList();

            // Assert.
            Assert.True(messages.Count > 0);
        }
    }
}