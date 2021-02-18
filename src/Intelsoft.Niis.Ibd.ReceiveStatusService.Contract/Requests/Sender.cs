using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests
{
    /// <summary>
    ///     Объект информация об отправителе (заполняется отправителем).
    /// </summary>
    [DataContract(Namespace = Globals.Empty)]
    public class Sender
    {
        /// <summary>
        ///     Идентификатор отправителя (системы отправителя).
        /// </summary>
        [DataMember(
            Order = 0,
            Name = "senderId")]
        public string SenderId { get; set; }

        /// <summary>
        ///     Пароль отправителя.
        /// </summary>
        [DataMember(
            Order = 1,
            Name = "password")]
        public string Password { get; set; }

        /// <summary>
        ///     Идентификатор сессии ШЭП.
        /// </summary>
        [DataMember(
            Order = 2,
            Name = "sessionId")]
        public string SessionId { get; set; }
    }
}