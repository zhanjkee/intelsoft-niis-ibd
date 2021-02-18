using Autofac;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Services;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Autofac
{
    public partial class ContractSenderServiceModule
    {
        public void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<Core.Services.ContractSenderService>()
                .As<IContractSenderService>()
                .InstancePerLifetimeScope();
        }
    }
}