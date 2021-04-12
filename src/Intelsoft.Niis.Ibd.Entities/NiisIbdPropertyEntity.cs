using System;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class NiisIbdPropertyEntity
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string ProtectionNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Name { get; set; }
        public DateTime? ValidityDate { get; set; }
    }
}
