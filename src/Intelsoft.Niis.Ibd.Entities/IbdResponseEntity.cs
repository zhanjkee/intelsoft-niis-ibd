using System;
using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Maps;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class IbdResponseEntity : EntityBase
    {
        public string ResponseId { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ErrorCode { get; set; }
        public string DataProcessingText { get; set; }
        public string RequestId { get; set; }

        public ICollection<IbdResponseMessageMapEntity> Messages { get; set; }
    }
}
