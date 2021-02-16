using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts
{
    /// <summary>
    ///     Запрос.
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class Request
    {
        /// <summary>
        ///     Метаданные сообщения.
        /// </summary>
        [DataMember(
            Order = 0,
            Name = "messageInfo")]
        public MessageInfo MessageInfo
        {
            get; set;
        }

        /// <summary>
        ///     Объект передачи данных.
        /// </summary>
        [DataMember(
            Order = 1,
            Name = "messageData")]
        public MessageData MessageData
        {
            get; set;
        }
    }
}