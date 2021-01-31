using System.Collections.Generic;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Services
{
    public interface IContractSenderService
    {
        /// <summary>
        ///     Получить список доступных договоров для отправки в ИБД.
        /// </summary>
        [ItemCanBeNull]
        IEnumerable<ContractRequestEntity> GetAvailableContracts();

        /// <summary>
        ///     Отправить договор в ИБД.
        /// </summary>
        void Send([NotNull] ContractRequestEntity contract);
    }
}