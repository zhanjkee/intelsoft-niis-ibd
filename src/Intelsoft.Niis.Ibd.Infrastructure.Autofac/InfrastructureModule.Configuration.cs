using Autofac;
using Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration;

namespace Intelsoft.Niis.Ibd.Infrastructure.Autofac
{
    public partial class InfrastructureModule
    {
        public void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.Register(x => new SerilogConfigurationReader().Read())
                .SingleInstance()
                .AsSelf()
                .AutoActivate();
        }
    }
}