using Autofac;
using Intelsoft.Niis.Ibd.Infrastructure.Logging;
using Serilog;

namespace Intelsoft.Niis.Ibd.Infrastructure.Autofac
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var instance = new SerilogLoggerFactory().CreateLogger();
                Log.Logger = instance;
                return instance;
            }).As<ILogger>().SingleInstance();
        }
    }
}
