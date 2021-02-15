using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts
{
    /// <summary>
    ///     Объект передачи данных.
    /// </summary>
    [DataContract(Namespace = Globals.EmptyNamespace)]
    public class MessageData
    {
        /// <summary>
        ///     Объект данные сообщения (формат определяется системой получателя сообщения).
        /// </summary>
        [DataMember(Name = "data")]
        public Data Data
        {
            get; set;
        }
    }
}