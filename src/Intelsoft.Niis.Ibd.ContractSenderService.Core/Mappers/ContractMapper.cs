using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contract;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData;
using Intelsoft.Niis.Ibd.Entities;
using System;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers
{
    public static class ContractMapper
    {
        public static ContractData ToDomain(this NiisIbdContractEntity entity)
        {
            if (entity == null)
                return null;

            return new ContractData
            {
                Property = entity.Property.ToDomain(),
                ContractType = entity.Type.ToDomain(),
                AssigneeName = entity.AssigneeName,
                Name = entity.Name,
                AssigneeXin = entity.AssigneeXin,
                ContractNumber = entity.ContractNumber,
                ContractRegistrationDate = entity.ContractRegistrationDate,
                Id = entity.Id,
                ContractValidityDate = entity.ContractValidityDate.HasValue ? entity.ContractValidityDate.Value : entity.Property.ValidityDate,
                CreatedDate = entity.CreatedDate ?? DateTime.Now,
                UpdatedDate = DateTime.Now,
                Xin = entity.Xin,
                ContractId = entity.ContractId,
                PropertyId = entity.PropertyId
            };
        }

        public static ContractReference ToDomain(this NiisIbdContractTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new ContractReference
            {
                Id = entity.Id,
                NameKz = entity.NameKz,
                NameRu = entity.NameRu
            };
        }
    }
}