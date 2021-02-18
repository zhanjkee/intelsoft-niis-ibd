using Autofac;

namespace Intelsoft.Niis.Ibd.Infrastructure.Autofac
{
    public partial class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterConfiguration(builder);
            RegisterSerilog(builder);
            RegisterSoapExecutor(builder);
        }
    }
}