using System.ServiceModel;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract
{
    [ServiceContract(Name = Globals.ReceiveStatusServiceContractName,
                     Namespace = Globals.ReceiveStatusServiceContractNameNamespace)]
    public interface IReceiveStatusService
    {
        /// <summary>
        ///     Метод для получение статуса от ИБД.
        /// </summary>
        /// <param name="response">Сообщение от ИБД.</param>
        [OperationContract(Action = Globals.ReceiveStatusServiceActionName)]
        void SendMessageResponse(string response);
    }
}
