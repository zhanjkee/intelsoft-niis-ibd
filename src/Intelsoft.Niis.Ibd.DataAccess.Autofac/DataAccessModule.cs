using System;
using System.Reflection;
using Autofac;
using Intelsoft.Niis.Ibd.DataAccess.Interfaces;
using Intelsoft.Niis.Ibd.DataAccess.UoW;
using Intelsoft.Niis.Ibd.Options;
using Microsoft.EntityFrameworkCore;
using AutofacModule = Autofac.Module;

namespace Intelsoft.Niis.Ibd.DataAccess.Autofac
{
    public class DataAccessModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<NiisIbdOptions>();

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
                .InstancePerLifetimeScope();

            builder.RegisterType<DataContextFactory>().As<IDataContextFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
