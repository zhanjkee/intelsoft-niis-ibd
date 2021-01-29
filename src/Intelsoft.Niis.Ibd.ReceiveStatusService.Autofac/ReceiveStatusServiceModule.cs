using Autofac;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac
{
    public class ReceiveStatusServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Implementation.ReceiveStatusService>().As<IReceiveStatusService>()
                .SingleInstance();

            builder.RegisterType<Implementation.ReceiveStatusService>()
                .SingleInstance();
        }
    }
}
