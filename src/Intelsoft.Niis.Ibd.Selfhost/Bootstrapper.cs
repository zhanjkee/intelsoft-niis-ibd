using Autofac;
using Intelsoft.Niis.Ibd.Configuration;
using Intelsoft.Niis.Ibd.ContractSenderService.Autofac;
using Intelsoft.Niis.Ibd.Data.Autofac;
using Intelsoft.Niis.Ibd.Infrastructure.Autofac;
using Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac;
using Intelsoft.Niis.Ibd.Selfhost.HostedServices;

namespace Intelsoft.Niis.Ibd.Selfhost
{
    public static class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            RegisterConfiguration(builder);
            RegisterModules(builder);
            RegisterHostedServices(builder);

            var container = builder.Build();
            return container;
        }

        private static void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.Register(x => NiisIbdSettingsReader.Read())
                .SingleInstance()
                .AsSelf()
                .AutoActivate();
        }

        private static void RegisterHostedServices(ContainerBuilder builder)
        {
            builder.RegisterType<ReceiveStatusHostedService>().SingleInstance();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<ReceiveStatusServiceModule>();
            builder.RegisterModule<ContractSenderServiceModule>();
        }
    }
}
