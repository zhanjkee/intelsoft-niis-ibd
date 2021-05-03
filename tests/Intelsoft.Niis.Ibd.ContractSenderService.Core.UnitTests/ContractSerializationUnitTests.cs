using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contract;
using Intelsoft.Niis.Ibd.Shared.Extensions;
using System;
using Xunit;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.UnitTests
{
    public class ContractSerializationUnitTests
    {
        [Fact]
        public void Serialization_Should_Success()
        {
            var contract = new ContractData
            {
                AssigneeName = "BRITISH-AMERICAN TOBACCO (HOLDINGS) LIMITED BRITISH-AMERICAN TOBACCO (HOLDINGS) LIMITED (GB)",
                AssigneeXin = string.Empty,
                ContractId = 123,
                ContractNumber = "asdf-1234",
                ContractRegistrationDate = DateTime.Now,
                ContractType = new Domain.ReferenceData.ContractReference
                {
                    Id = 1,
                    NameRu = "asd",
                    NameKz = "asd"
                },
                Xin = string.Empty
            };

            var xml = contract.SerializeToString();

            Assert.True(true);
        }
    }
}
