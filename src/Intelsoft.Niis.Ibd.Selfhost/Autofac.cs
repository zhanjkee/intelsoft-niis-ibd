using System;
using Autofac;
using Intelsoft.Niis.Ibd.ContractSenderService.Configuration;

namespace Intelsoft.Niis.Ibd.Selfhost
{
    public sealed class Autofac
    {
        private static readonly Lazy<Autofac> Lazy = new Lazy<Autofac>(() => new Autofac());

        private Autofac()
        {
            Container = Bootstrapper.BuildContainer();
            ContractSenderServiceConfiguration = Container.Resolve<ContractSenderServiceConfiguration>();
        }

        public static Autofac Instance => Lazy.Value;

        public IContainer Container { get; }

        public ContractSenderServiceConfiguration ContractSenderServiceConfiguration { get; }
    }
}