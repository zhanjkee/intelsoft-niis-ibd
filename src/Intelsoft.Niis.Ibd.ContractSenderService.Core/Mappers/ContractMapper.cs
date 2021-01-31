using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contracts;
using Intelsoft.Niis.Ibd.Entities;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers
{
    public static class ContractMapper
    {
        public static Contract ToDomain(this ContractRequestEntity entity)
        {
            if (entity == null)
                return null;

            return new Contract
            {
                Property = entity.Property.ToDomain(),
                ContractType = entity.Type.ToDomain(),
                AssigneeName = entity.AssigneeName,
                Name = entity.Name,
                AssigneeXin = entity.AssigneeXin,
                ContractNumber = entity.ContractNumber,
                ContractRegistrationDate = entity.ContractRegistrationDate,
                Id = entity.Id,
                ContractValidityDate = entity.ContractValidityDate,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                Xin = entity.Xin
            };
        }

        public static ContractType ToDomain(this ContractTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new ContractType
            {
                Id = entity.Id,
                NameKz = entity.NameKz,
                NameRu = entity.NameRu
            };
        }
    }
}
