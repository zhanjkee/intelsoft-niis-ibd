using Autofac;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac
{
    public partial class ReceiveStatusServiceModule
    {
        public void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<Implementation.ReceiveStatusService>().As<IReceiveStatusService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Implementation.ReceiveStatusService>()
                .InstancePerLifetimeScope();
        }
    }
}