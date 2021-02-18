using Autofac;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Autofac
{
    public partial class ContractSenderServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterConfiguration(builder);
            RegisterServices(builder);
        }
    }
}