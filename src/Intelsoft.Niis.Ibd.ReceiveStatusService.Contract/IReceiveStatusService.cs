using System.ServiceModel;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Requests;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract
{
    /// <summary>
    ///     The Receive status service.
    /// </summary>
    [ServiceContract(
        Name = Globals.ServiceActionName,
        Namespace = Globals.ServiceContractNamespace)]
    public interface IReceiveStatusService
    {
        /// <summary>
        ///     Метод для получение статуса от ИБД.
        /// </summary>
        /// <param name="request">Сообщение от ИБД</param>
        [OperationContract(
            Name = Globals.SendMessage,
            Action = Globals.Empty)]
        void SendMessage(SendMessageRequest request);
    }
}