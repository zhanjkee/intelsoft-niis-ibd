using System;
using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts
{
    /// <summary>
    ///     Метаданные сообщения.
    /// </summary>
    [DataContract(Namespace = Globals.EmptyNamespace)]
    public class MessageInfo
    {
        /// <summary>
        ///     Идентификатор сообщения в системе получателя
        ///     (заполняет система получателя запроса (система отрабатывающая сообщение).
        /// </summary>
        [DataMember(
            Order = 0,
            Name = "messageId")]
        public string MessageId
        {
            get;
            set;
        }

        /// <summary>
        ///     Идентификатор цепочки сообщения в системе получателя запроса
        ///     (если сообщения существует в рамках цепочки сообщений системы (отправителя)
        ///     система отрабатывающая сообщение).
        /// </summary>
        [DataMember(
            Order = 1,
            Name = "correlationId")]
        public string CorrelationId
        {
            get;
            set;
        }

        /// <summary>
        ///     Идентификатор сервиса.
        /// </summary>
        [DataMember(
            Order = 2,
            Name = "serviceId")]
        public string ServiceId
        {
            get;
            set;
        }

        /// <summary>
        ///     Тип сообщения: REQUEST - первое сообщения взаимодействия.
        /// </summary>
        [DataMember(
            Order = 3,
            Name = "messageType")]
        public string MessageType
        {
            get;
            set;
        }

        /// <summary>
        ///     Дата создания сообщения.
        /// </summary>
        [DataMember(
            Order = 4,
            Name = "messageDate")]
        public DateTime? MessageDate
        {
            get;
            set;
        }

        /// <summary>
        ///     Объект информация об отправителе (заполняется отправителем).
        /// </summary>
        [DataMember(
            Order = 5,
            Name = "sender")]
        public Sender Sender
        {
            get;
            set;
        }

        /// <summary>
        ///     Идентификатор сессии, в которой произошла ошибка.
        /// </summary>
        [DataMember(
            Order = 6,
            Name = "sessionId")]
        public string SessionId
        {
            get;
            set;
        }
    }
}