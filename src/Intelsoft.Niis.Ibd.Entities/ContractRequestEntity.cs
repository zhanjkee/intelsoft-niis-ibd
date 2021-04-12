using System;
using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Maps;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class ContractRequestEntity : EntityBase
    {
        /// <summary>
        ///     Идентификатор.
        /// </summary>
        public int ContractId { get; set; }
        public int PropertyId { get; set; }
        public bool Dispatched { get; set; }
        public DateTime? DispatchingDate { get; set; }

        public ICollection<ContractRequestMessageMapEntity> Messages { get; set; }

        public void Dispatch()
        {
            Dispatched = true;
            DispatchingDate = DateTime.Now;
        }
    }
}