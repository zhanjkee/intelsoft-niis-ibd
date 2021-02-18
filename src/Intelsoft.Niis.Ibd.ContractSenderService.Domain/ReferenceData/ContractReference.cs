using System;
using System.Xml.Serialization;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain.ReferenceData
{
    /// <summary>
    ///     Договор.
    /// </summary>
    [Serializable]
    //[XmlType("ContractType")]
    public class ContractReference
    {
        /// <summary>
        ///     Id типа договора.
        /// </summary>
        [XmlElement]
        public int Id { get; set; }

        /// <summary>
        ///     Название договора (на русском).
        /// </summary>
        [XmlElement]
        public string NameRu { get; set; }

        /// <summary>
        ///     Название договора (на кахахском).
        /// </summary>
        [XmlElement]
        public string NameKz { get; set; }
    }
}