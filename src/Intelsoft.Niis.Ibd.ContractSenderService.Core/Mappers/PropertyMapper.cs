using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Property;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData;
using Intelsoft.Niis.Ibd.Entities;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Mappers
{
    public static class PropertyMapper
    {
        public static PropertyData ToDomain(this NiisIbdPropertyEntity entity)
        {
            if (entity == null)
                return null;

            return new PropertyData
            {
                Name = entity.Name,
                ProtectionNumber = entity.ProtectionNumber,
                RegistrationDate = entity.RegistrationDate.Value,
                Type = entity.Type > 7 ? PropertyReference.Undefined : (PropertyReference)entity.Type,
                ValidityDate = entity.ValidityDate.Value
            };
        }
    }
}