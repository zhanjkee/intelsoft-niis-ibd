using System;
using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities.Base;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Intelsoft.Niis.Ibd.Entities.Maps;

namespace Intelsoft.Niis.Ibd.Entities
{
    public class MessageEntity : EntityBase
    {
        protected MessageEntity()
        {

        }

        public MessageEntity(
            string messageId,
            DateTime? messageDate,
            string correlationId,
            Method method,
            Direction from,
            Direction to,
            string rawData)
        {
            MessageId = messageId;
            MessageDate = messageDate;
            CorrelationId = correlationId;
            Method = method;
            From = from;
            To = to;
            RawData = rawData;
        }

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
        public Direction From { get; set; }

        /// <summary>
        ///     Направление. Niis | Ibd.
        /// </summary>
        public Direction To { get; set; }

        /// <summary>
        ///     Сообщение xml в сыром виде.
        /// </summary>
        public string RawData { get; set; }

        public ICollection<ContractRequestMessageMapEntity> ContractRequests { get; set; }
        public ICollection<IbdResponseMessageMapEntity> IbdResponses { get; set; }

        public void AddIdbResponses(params IbdResponseEntity[] ibdResponses)
        {
            if (IbdResponses == null) IbdResponses = new List<IbdResponseMessageMapEntity>(ibdResponses.Length);

            foreach (var ibdResponse in ibdResponses)
            {
                IbdResponses.Add(new IbdResponseMessageMapEntity(ibdResponse, this));
            }
        }
    }
}
