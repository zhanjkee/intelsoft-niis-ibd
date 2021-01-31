using Intelsoft.Niis.Ibd.ContractSenderService.Domain.IntellectualProperties;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers
{
    public static class PropertyMapper
    {
        public static Property ToDomain(this PropertyEntity entity)
        {
            if (entity == null)
                return null;

            return new Property
            {
                Name = entity.Name,
                ProtectionNumber = entity.ProtectionNumber,
                RegistrationDate = entity.RegistrationDate,
                Type = entity.Type.ToDomain(),
                ValidityDate = entity.ValidityDate
            };
        }

        public static PropertyType ToDomain(this PropertyTypeEntity entity)
        {
            return (PropertyType)entity;
        }
    }
}
