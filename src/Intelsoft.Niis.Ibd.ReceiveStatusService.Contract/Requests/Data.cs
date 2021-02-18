using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests
{
    /// <summary>
    ///     Объект данные сообщения (формат определяется системой получателя сообщения).
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class Data
    {
        /// <summary>
        ///     Ответ на получение статуса обработки данных в ИБД.
        /// </summary>
        [DataMember]
        public IdbDataProcessingResponse IdbDataProcessingResponse { get; set; }
    }
}