using System.ServiceModel;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract
{
    /// <summary>
    ///     
    /// </summary>
    [ServiceContract(
        Name = Globals.ServiceActionName,
        Namespace = Globals.ServiceContractNamespace)]
    public interface ISendMessageResponseService
    {
        /// <summary>
        ///     Метод для получение статуса от ИБД
        /// </summary>
        /// <param name="request">Сообщение от ИБД</param>
        [OperationContract(
            Name = Globals.SendMessage,
            Action = Globals.SendMessage)]
        void SendMessage(SendMessageResponse request);
    }
}
