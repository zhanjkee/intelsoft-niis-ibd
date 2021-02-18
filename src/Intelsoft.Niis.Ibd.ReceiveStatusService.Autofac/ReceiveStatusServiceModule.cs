using Autofac;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac
{
    public partial class ReceiveStatusServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterConfiguration(builder);
            RegisterServices(builder);
        }
    }
}