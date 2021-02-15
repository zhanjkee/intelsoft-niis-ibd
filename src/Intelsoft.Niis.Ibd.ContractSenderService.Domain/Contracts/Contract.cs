using System;
using System.Xml.Serialization;
using Intelsoft.Niis.Ibd.ContractSenderService.Domain.IntellectualProperties;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.Contracts
{
    [Serializable]
    [XmlType("PropertyRightsInfo")]
    public class Contract
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Xin { get; set; }
        public string Name { get; set; }
        public Property Property { get; set; }
        public string AssigneeXin { get; set; }
        public string AssigneeName { get; set; }
        public string ContractNumber { get; set; }

        [XmlElement(DataType = "date")]
        public DateTime? ContractRegistrationDate { get; set; }
        public ContractType ContractType { get; set; }

        [XmlElement(DataType = "date")]
        public DateTime? ContractValidityDate
        {
            get => _contractValidityDate ?? Property?.ValidityDate ?? default;
            set => _contractValidityDate = value;
        }
        private DateTime? _contractValidityDate;

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
