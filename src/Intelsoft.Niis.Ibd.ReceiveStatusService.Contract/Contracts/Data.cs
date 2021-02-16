using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts
{
    /// <summary>
    ///     Объект данные сообщения (формат определяется системой получателя сообщения).
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class Data
    {
        /// <summary>
        ///     Gets or sets the idb data processing response.
        /// </summary>
        [DataMember]
        public IdbDataProcessingResponse IdbDataProcessingResponse { get; set; }
    }
}