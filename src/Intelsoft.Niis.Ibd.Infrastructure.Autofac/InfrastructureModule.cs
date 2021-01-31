using Autofac;
using Intelsoft.Niis.Ibd.Configuration;
using Intelsoft.Niis.Ibd.Infrastructure.Logging;
using Intelsoft.Niis.Ibd.Infrastructure.Soap;
using Serilog;

namespace Intelsoft.Niis.Ibd.Infrastructure.Autofac
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SoapClient>()
                .As<ISoapClient>()
                .SingleInstance();

            builder.Register(x =>
                {
                    var configuration =  x.Resolve<NiisIbdSettings>();
                    var instance = new SerilogLoggerFactory(configuration).CreateLogger();
                    Log.Logger = instance;
                    return instance;
                })
                .AsSelf()
                .AutoActivate();
        }
    }
}
