using System;
using System.Linq;
using System.Threading;
using Autofac;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Services;
using Quartz;
using Serilog;

namespace Intelsoft.Niis.Ibd.Selfhost.Jobs
{
    public class ContractSenderJob : IJob
    {
        private static readonly object _syncObject = new object();

        private readonly IContractSenderService _contractSenderService;
        private readonly ILogger _logger;

        public ContractSenderJob()
        {
            // TODO: Отчерафить. Реализовать внедрение через конструктор.
            var contractSenderService = Global.Instance.Container.Resolve<IContractSenderService>();
            _contractSenderService =
                contractSenderService ?? throw new ArgumentNullException(nameof(contractSenderService));

            _logger = Global.Instance.Container.Resolve<ILogger>();
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Monitor.Enter(_syncObject);

                var contracts = _contractSenderService.GetAvailableContracts()?.ToList();

                if (contracts == null || !contracts.Any())
                    return;

                foreach (var contract in contracts)
                {
                    _contractSenderService.Send(contract);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, nameof(ContractSenderJob));
            }
            finally
            {
                Monitor.Exit(_syncObject);
            }
        }
    }
}
