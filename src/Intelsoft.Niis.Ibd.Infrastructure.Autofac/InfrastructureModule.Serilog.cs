using Autofac;
using Intelsoft.Niis.Ibd.Infrastructure.Logging;
using Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration;
using Serilog;

namespace Intelsoft.Niis.Ibd.Infrastructure.Autofac
{
    public partial class InfrastructureModule
    {
        public void RegisterSerilog(ContainerBuilder builder)
        {
            builder.Register(x =>
                {
                    var configuration = x.Resolve<SerilogConfiguration>();
                    Log.Logger = new SerilogLoggerFactory(configuration).CreateLogger();
                    return Log.Logger;
                })
                .AsSelf()
                .AutoActivate();
        }
    }
}