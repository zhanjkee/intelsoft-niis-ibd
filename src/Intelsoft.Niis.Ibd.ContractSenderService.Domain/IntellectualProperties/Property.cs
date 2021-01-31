using System;
using System.Xml.Serialization;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.IntellectualProperties
{
    [Serializable]
    public class Property
    {
        public PropertyType Type { get; set; }
        public string ProtectionNumber { get; set; }
        public string Name { get; set; }

        [XmlElement(DataType = "date")] 
        public DateTime RegistrationDate { get; set; }

        [XmlElement(DataType = "date")]
        public DateTime ValidityDate { get; set; }
    }
}