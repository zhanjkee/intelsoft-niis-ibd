using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelsoft.Niis.Ibd.Entities
{
    /// <summary>
    ///     Представление NiisIbdContract
    /// </summary>
    public class NiisIbdContractEntity
    {
        public long Id { get; set; }
        public int ContractId { get; set; }
        public string Xin { get; set; }
        public string Name { get; set; }
        public int PropertyId { get; set; }
        [NotMapped]
        public NiisIbdPropertyEntity Property { get; set; }
        public string AssigneeXin { get; set; }
        public string AssigneeName { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractRegistrationDate { get; set; }
        public int TypeId { get; set; }
        [NotMapped]
        public NiisIbdContractTypeEntity Type { get; set; }
        public DateTime? ContractValidityDate { get; set; }   
        public DateTime? CreatedDate { get; set; }
    }
}
