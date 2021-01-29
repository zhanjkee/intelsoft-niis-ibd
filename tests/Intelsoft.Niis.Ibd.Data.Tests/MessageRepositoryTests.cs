using System;
using System.Linq;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.UoW;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Xunit;

namespace Intelsoft.Niis.Ibd.Data.Tests
{
    public class MessageRepositoryTests
    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageRepositoryTests()
        {
            _unitOfWork = new UnitOfWork(new InMemoryDataContextFactory());
        }

        [Fact]
        public void AddMessageTests()
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
                Method.Request,
                Direction.Ibd,
                Direction.Niis,
                string.Empty
            ));
            _unitOfWork.SaveChanges();

            var messages = _unitOfWork.MessageRepository.GetAll().ToList();

            // Assert.
            Assert.True(messages.Count > 0);
        }
    }
}
