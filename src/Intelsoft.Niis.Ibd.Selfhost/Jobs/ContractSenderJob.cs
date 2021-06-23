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
        private static readonly object Locker = new object();

        private readonly IContractSenderService _contractSenderService;
        private readonly ILogger _logger;

        public ContractSenderJob()
        {
            // NOTE: Резолвим зависимости. По умолчанию Job-ы не подерживают DI.
            _contractSenderService = Autofac.Instance.Container.Resolve<IContractSenderService>();
            _logger = Autofac.Instance.Container.Resolve<ILogger>();
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Monitor.Enter(Locker);

                var availableContracts = _contractSenderService.GetAvailableContracts();
                if (availableContracts == null)
                    return;

                var contractRequests = availableContracts.ToList();
                foreach (var contractRequest in contractRequests)
                {
                    try
                    {
                        _contractSenderService.Send(contractRequest);
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e, nameof(IContractSenderService.Send));
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, nameof(ContractSenderJob));
            }
            finally
            {
                Monitor.Exit(Locker);
            }
        }
    }
}