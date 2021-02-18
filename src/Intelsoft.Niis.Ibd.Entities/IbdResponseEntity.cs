using System;
using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Maps;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class IbdResponseEntity : EntityBase
    {
        protected IbdResponseEntity()
        {
        }

        public IbdResponseEntity(
            string responseId,
            DateTime? responseDate,
            string errorCode,
            string dataProcessingText,
            string requestId)
        {
            ResponseId = responseId;
            ResponseDate = responseDate;
            ErrorCode = errorCode;
            DataProcessingText = dataProcessingText;
            RequestId = requestId;
        }

        public string ResponseId { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ErrorCode { get; set; }
        public string DataProcessingText { get; set; }
        public string RequestId { get; set; }

        public ICollection<IbdResponseMessageMapEntity> Messages { get; set; }
    }
}