using System;
using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class ContractDispatchStatusEntity : EntityBase
    {
        public bool Dispatched { get; set; }
        public DateTime DispatchingDate { get; set; }

        public void Dispatch()
        {
            Dispatched = true;
            DispatchingDate = DateTime.Now;
        }
    }
}
