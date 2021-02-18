using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests
{
    /// <summary>
    ///     Объект передачи данных.
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class MessageData
    {
        /// <summary>
        ///     Объект данные сообщения (формат определяется системой получателя сообщения).
        /// </summary>
        [DataMember(Name = "data")]
        public Data Data { get; set; }
    }
}