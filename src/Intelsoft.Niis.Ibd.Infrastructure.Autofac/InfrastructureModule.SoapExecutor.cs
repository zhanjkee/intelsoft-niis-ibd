using Autofac;
using Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor;

namespace Intelsoft.Niis.Ibd.Infrastructure.Autofac
{
    public partial class InfrastructureModule
    {
        public void RegisterSoapExecutor(ContainerBuilder builder)
        {
            builder.RegisterType<SoapExecutor.SoapExecutor>()
                .As<ISoapExecutor>()
                .SingleInstance();
        }
    }
}