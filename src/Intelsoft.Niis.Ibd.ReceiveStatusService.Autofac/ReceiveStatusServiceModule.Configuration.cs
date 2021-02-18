using Autofac;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Configuration;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac
{
    public partial class ReceiveStatusServiceModule
    {
        public void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.Register(x => new ReceiveStatusServiceConfigurationReader().Read())
                .SingleInstance()
                .AsSelf()
                .AutoActivate();
        }
    }
}