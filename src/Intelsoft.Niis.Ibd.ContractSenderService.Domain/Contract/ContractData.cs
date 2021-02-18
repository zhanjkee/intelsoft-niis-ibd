using System;
using System.Xml.Serialization;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.Property;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contract
{
    /// <summary>
    ///     Сведения о распоряжении имущественными правами.
    /// </summary>
    [Serializable]
    [XmlType("PropertyRightsInfo")]
    public class ContractData
    {
        private DateTime? _contractValidityDate;

        [XmlIgnore] public int Id { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public string Xin { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public PropertyData Property { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public string AssigneeXin { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public string AssigneeName { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public string ContractNumber { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime? ContractRegistrationDate { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public ContractReference ContractType { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime? ContractValidityDate
        {
            get => _contractValidityDate ?? Property?.ValidityDate ?? default;
            set => _contractValidityDate = value;
        }


        /// <summary>
        /// </summary>
        [XmlElement]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [XmlElement]
        public DateTime? UpdatedDate { get; set; }
    }
}