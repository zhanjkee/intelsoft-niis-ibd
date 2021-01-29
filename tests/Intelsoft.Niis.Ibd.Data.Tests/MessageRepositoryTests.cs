using System;
using System.Diagnostics;
using System.Linq;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.UoW;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Microsoft.EntityFrameworkCore;
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
            _unitOfWork.MessageRepository.Add(new MessageEntity
            {
                CorrelationId = Guid.NewGuid().ToString(),
                Direction = Direction.Niis,
                Method = Method.Request,
                MessageId = Guid.NewGuid().ToString(),
                RawData = string.Empty,
                MessageDate = DateTime.Now
            });
            _unitOfWork.SaveChanges();

            var messages = _unitOfWork.MessageRepository.GetAll().ToList();

            Assert.True(messages.Count > 0);
        }
    }
}
