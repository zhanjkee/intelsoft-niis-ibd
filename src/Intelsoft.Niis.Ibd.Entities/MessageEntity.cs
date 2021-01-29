using System;
using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Entities.Maps;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class MessageEntity : EntityBase
    {
        /// <summary>
        ///     Идентификатор сообщения.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        ///     Дата сообщения.
        /// </summary>
        public DateTime? MessageDate { get; set; }

        /// <summary>
        ///     Идентификатор цепочки.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        ///     Метод сообщения. Request | Reply.
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        ///     Направление. Niis | Ibd.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        ///     Сообщение xml в сыром виде.
        /// </summary>
        public string RawData { get; set; }

        public ICollection<ContractRequestMessageMapEntity> ContractRequests { get; set; }
        public ICollection<IbdResponseMessageMapEntity> IbdResponses { get; set; }
    }
}
