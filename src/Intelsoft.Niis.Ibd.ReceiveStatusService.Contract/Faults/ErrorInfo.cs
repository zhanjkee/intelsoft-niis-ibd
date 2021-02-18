using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Faults
{
    /// <summary>
    ///     Информация об ошибке.
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class ErrorInfo
    {
        public ErrorInfo()
        {
            ErrorDate = DateTime.Now;
        }

        /// <summary>
        ///     Код ошибки.
        /// </summary>
        [Required]
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Дополнительное описание ошибки.
        /// </summary>
        [Required]
        [DataMember(Name = "errorData")]
        public string ErrorData { get; set; }

        /// <summary>
        ///     Дата ошибки.
        /// </summary>
        [Required]
        [DataMember(Name = "errorDate")]
        public DateTime ErrorDate { get; set; }

        /// <summary>
        ///     Дочерняя ошибка.
        /// </summary>
        [DataMember(Name = "subError")]
        public ErrorInfo SubError { get; set; }

        /// <summary>
        ///     Идентификатор сессии в которой произошла ошибка.
        /// </summary>
        [DataMember(Name = "sessionId")]
        public Guid SessionId { get; set; }
    }
}