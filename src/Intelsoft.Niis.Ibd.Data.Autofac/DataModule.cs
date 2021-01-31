using System;
using System.Reflection;
using Autofac;
using Intelsoft.Niis.Ibd.Configuration;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.Repositories;
using Intelsoft.Niis.Ibd.Data.UoW;
using Microsoft.EntityFrameworkCore;
using AutofacModule = Autofac.Module;

namespace Intelsoft.Niis.Ibd.Data.Autofac
{
    public class DataModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<NiisIbdSettings>();

                var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(configuration.ConnectionString,
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(DataContext).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30),
                                null);
                        });
                var dbContextOptions = dbContextOptionsBuilder.Options;
                return dbContextOptions;
            }).SingleInstance();

            builder.RegisterType<DataContext>().As<IDataContext>()
                .InstancePerDependency();

            builder.RegisterType<DataContextFactory>().As<IDataContextFactory>()
                .InstancePerDependency();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerDependency();

            builder.RegisterType<MessageRepository>().As<IMessageRepository>()
                .InstancePerDependency();

            builder.RegisterType<ContractRepository>().As<IContractRepository>()
                .InstancePerDependency();
        }
    }
}
