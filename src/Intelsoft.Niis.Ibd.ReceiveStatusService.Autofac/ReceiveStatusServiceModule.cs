using Autofac;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Contract;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac
{
    public class ReceiveStatusServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Implementation.SendMessageResponseService>().As<ISendMessageResponseService>()
                .SingleInstance();

            builder.RegisterType<Implementation.SendMessageResponseService>()
                .SingleInstance();
        }
    }
}
