using Autofac;
using Intelsoft.Niis.Ibd.ContractSenderService.Configuration;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Autofac
{
    public partial class ContractSenderServiceModule
    {
        public void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.Register(x => new ContractSenderServiceConfigurationReader().Read())
                .SingleInstance()
                .AsSelf()
                .AutoActivate();
        }
    }
}