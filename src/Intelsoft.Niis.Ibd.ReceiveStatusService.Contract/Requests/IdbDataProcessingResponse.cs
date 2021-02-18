using System;
using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests
{
    /// <summary>
    ///     Ответ на получение статуса обработки данных в ИБД.
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class IdbDataProcessingResponse
    {
        /// <summary>
        ///     ID ответа, на который формирует ответ.
        /// </summary>
        [DataMember(Order = 0)]
        public string IdbResponseId { get; set; }

        /// <summary>
        ///     Дата и время формирования ответа из ИС ИБД.
        /// </summary>
        [DataMember(Order = 1)]
        public DateTime? IdbResponseDate { get; set; }

        /// <summary>
        ///     Код обработки сообщения.
        /// </summary>
        /// <remarks>
        ///     000 - Сообщение обработано успешно
        ///     001 - Несоответствие xs
        /// </remarks>
        [DataMember(Order = 2)]
        public string IdbErrorCode { get; set; }

        /// <summary>
        ///     Текстовое описание результата обработки, включая ошибочные.
        /// </summary>
        [DataMember(Order = 3)]
        public string IdbDataProcessingText { get; set; }

        /// <summary>
        ///     ID запроса, на который формирует ответ.
        /// </summary>
        [DataMember(Order = 4)]
        public string IdbRequestId { get; set; }
    }
}