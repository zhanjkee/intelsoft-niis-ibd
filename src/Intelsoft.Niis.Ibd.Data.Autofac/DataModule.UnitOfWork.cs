using Autofac;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.Repositories;
using Intelsoft.Niis.Ibd.Data.UoW;

namespace Intelsoft.Niis.Ibd.Data.Autofac
{
    public partial class DataModule
    {
        public void RegisterUnitOfWork(ContainerBuilder builder)
        {
            // Register unit of work.
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerDependency();

            // Register repositories.
            builder.RegisterType<MessageRepository>().As<IMessageRepository>()
                .InstancePerDependency();

            builder.RegisterType<ContractRepository>().As<IContractRepository>()
                .InstancePerDependency();

            builder.RegisterType<ContractRequestMessageMapRepository>().As<IContractRequestMessageMapRepository>()
                .InstancePerDependency();

            builder.RegisterType<IbdResponseRepository>().As<IIbdResponseRepository>()
                .InstancePerDependency();

            builder.RegisterType<IbdResponseMessageMapRepository>().As<IIbdResponseMessageMapRepository>()
                .InstancePerDependency();
        }
    }
}