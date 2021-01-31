using System;
using Autofac;
using Intelsoft.Niis.Ibd.Configuration;
using Intelsoft.Niis.Ibd.ContractSenderService.Autofac;
using Intelsoft.Niis.Ibd.Data.Autofac;
using Intelsoft.Niis.Ibd.Infrastructure.Autofac;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Tests
{
    public static class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            try
            {
                var builder = new ContainerBuilder();

                RegisterConfiguration(builder);
                RegisterModules(builder);

                var container = builder.Build();
                return container;
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        private static void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.Register(x => NiisIbdSettingsReader.Read())
                .SingleInstance()
                .AsSelf()
                .AutoActivate();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<ContractSenderServiceModule>();
        }
    }
}
