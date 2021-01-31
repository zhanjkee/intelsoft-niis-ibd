using System;
using Autofac;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Services;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Xunit;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Tests
{
    public class ContractSenderServiceTests
    {
        private readonly IContractSenderService _contractSenderService;

        public ContractSenderServiceTests()
        {
            var container = Bootstrapper.BuildContainer();
            _contractSenderService = container.Resolve<IContractSenderService>();
        }

        [Fact]
        public void SendTests()
        {
            // Arrange.
            var contract = new ContractRequestEntity
            {
                AssigneeName = "Тест Тестов Тестович",
                AssigneeXin = "123456789011",
                ContractNumber = "12345",
                ContractRegistrationDate = DateTime.Now,
                Type = new ContractTypeEntity { Id = 1, NameKz = "Тестовый договор", NameRu = "Тестовый договор" },
                Id = 1,
                //ContractValidityDate = DateTime.Now,
                Name = "Тестовый договор",
                Xin = "123456789011",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Property = new PropertyEntity
                {
                    Name = "Coca-cola",
                    ProtectionNumber = "12345",
                    RegistrationDate = DateTime.Now,
                    Type = PropertyTypeEntity.Trademark,
                    ValidityDate = DateTime.Now.AddYears(2)
                }
            };

            // Act.
            _contractSenderService.Send(contract);

            // Assert.
            Assert.NotNull(contract.ContractValidityDate.Value);
        }
    }
}
