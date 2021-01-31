using System;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.IntellectualProperties
{
    [Serializable]
    public enum PropertyType
    {
        Invention = 1,
        UsefulModel = 2,
        IndustrialDesign = 3,
        Trademark = 4,
        GeographicalIndication = 5,
        PlantBreedersRights = 6,
        InternationalTrademark = 7
    }
}
