using Autofac;
using Intelsoft.Niis.Ibd.ContractSenderService.Core.Services;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Autofac
{
    public class ContractSenderServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Core.Services.ContractSenderService>()
                .As<IContractSenderService>()
                .InstancePerLifetimeScope();
        }
    }
}
