using System;
using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class ContractRequestDispatchStatusEntity : EntityBase
    {
        public bool Dispatched { get; set; }
        public DateTime? DispatchingDate { get; set; }

        public int ContractRequestId { get; set; }
        public ContractRequestEntity ContractRequest { get; set; }

        public void Dispatch()
        {
            Dispatched = true;
            DispatchingDate = DateTime.Now;
        }
    }
}