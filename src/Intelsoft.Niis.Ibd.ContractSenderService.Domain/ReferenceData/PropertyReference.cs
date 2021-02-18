using System;
using System.Xml.Serialization;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData
{
    [Serializable]
    //[XmlType("Type")]
    public enum PropertyReference
    {
        /// <summary>
        ///     Изобретение.
        /// </summary>
        [XmlEnum] Invention = 1,

        /// <summary>
        ///     Полезная модель.
        /// </summary>
        [XmlEnum] UsefulModel = 2,

        /// <summary>
        ///     Промышленный образец.
        /// </summary>
        [XmlEnum] IndustrialDesign = 3,

        /// <summary>
        ///     Товарный знак.
        /// </summary>
        [XmlEnum] Trademark = 4,

        /// <summary>
        ///     Наименование мест происхождения товаров.
        /// </summary>
        [XmlEnum] GeographicalIndication = 5,

        /// <summary>
        ///     Селекционные достижения.
        /// </summary>
        [XmlEnum] PlantBreedersRights = 6,

        /// <summary>
        ///     Международные товарные знаки.
        /// </summary>
        [XmlEnum] InternationalTrademark = 7,

        /// <summary>
        ///     Неизвестный тип.
        /// </summary>
        [XmlEnum] Undefined = 0
    }
}