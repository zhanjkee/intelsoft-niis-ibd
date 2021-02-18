using System;
using System.Xml.Serialization;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.Property
{
    /// <summary>
    ///     Объект интеллектуальной собственности.
    /// </summary>
    [Serializable]
    //[XmlType("Property")]
    public class PropertyData
    {
        /// <summary>
        ///     Вид объекта.
        /// </summary>
        [XmlElement]
        public PropertyReference Type { get; set; }

        /// <summary>
        ///     Номер охранного документа.
        /// </summary>
        [XmlElement]
        public string ProtectionNumber { get; set; }

        /// <summary>
        ///     Название объекта.
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        ///     Дата регистрации.
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        ///     Срок действия охранного документа.
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime ValidityDate { get; set; }
    }
}