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
            MethodEntity method,
            DirectionEntity from,
            DirectionEntity to,
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
        public MethodEntity Method { get; set; }

        /// <summary>
        ///     Направление. Niis | Ibd.
        /// </summary>
        public DirectionEntity From { get; set; }

        /// <summary>
        ///     Направление. Niis | Ibd.
        /// </summary>
        public DirectionEntity To { get; set; }

        /// <summary>
        ///     Сообщение xml в сыром виде.
        /// </summary>
        public string RawData { get; set; }

        public ICollection<ContractRequestMessageMapEntity> ContractRequests { get; set; }
        public ICollection<IbdResponseMessageMapEntity> IbdResponses { get; set; }

        public void AddIdbResponses(params IbdResponseEntity[] ibdResponses)
        {
            if (ibdResponses == null || ibdResponses.Length == 0) return;


            if (IbdResponses == null) IbdResponses = new List<IbdResponseMessageMapEntity>(ibdResponses.Length);

            foreach (var ibdResponse in ibdResponses)
            {
                IbdResponses.Add(new IbdResponseMessageMapEntity(ibdResponse, this));
            }
        }

        public void AddContractRequests(params ContractRequestEntity[] contractRequests)
        {
            if (contractRequests == null || contractRequests.Length == 0) return;
            
            if (ContractRequests == null) ContractRequests = new List<ContractRequestMessageMapEntity>(contractRequests.Length);

            foreach (var contractRequest in contractRequests)
            {
                ContractRequests.Add(new ContractRequestMessageMapEntity(contractRequest, this));
            }
        }
    }
}
