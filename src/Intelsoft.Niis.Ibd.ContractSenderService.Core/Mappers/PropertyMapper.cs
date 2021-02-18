using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Property;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers
{
    public static class PropertyMapper
    {
        public static PropertyData ToDomain(this PropertyEntity entity)
        {
            if (entity == null)
                return null;

            return new PropertyData
            {
                Name = entity.Name,
                ProtectionNumber = entity.ProtectionNumber,
                RegistrationDate = entity.RegistrationDate,
                Type = entity.Type.ToDomain(),
                ValidityDate = entity.ValidityDate
            };
        }

        public static PropertyReference ToDomain(this PropertyTypeEntity entity)
        {
            return (PropertyReference) entity;
        }
    }
}