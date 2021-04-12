using System;
using System.Linq;
using Autofac;
using Intelsoft.Niis.Ibd.Data.Configuration;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data.Autofac
{
    public partial class DataModule
    {
        public void RegisterDataContext(ContainerBuilder builder)
        {
            // Register db context options.
            builder.Register(x =>
                {
                    var configuration = x.Resolve<ConnectionStringsConfiguration>();

                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>()
                        .UseSqlServer(configuration.ConnectionString);

                    return dbContextOptionsBuilder.Options;
                })
                .SingleInstance();

            // Register data context.
            builder.Register<IDataContext>(provider =>
                {
                    var options = provider.Resolve<DbContextOptions<DataContext>>();
                    if (options == null) throw new NullReferenceException(nameof(options));

                    var context = new DataContext(options);

                    var migrations = context.Database.GetPendingMigrations();
                    if (migrations != null && migrations.Any())
                        context.Database.Migrate();

                    return context;
                })
                .InstancePerDependency();

            // Register data context.
            builder.Register(provider =>
            {
                var configuration = provider.Resolve<ConnectionStringsConfiguration>();

                var options = new DbContextOptionsBuilder<NiisDbContext>()
                    .UseSqlServer(configuration.NiisConnectionString)
                    .Options;

                return new NiisDbContext(options);
            })
                .InstancePerDependency();

            // Register data context factory.
            builder.RegisterType<DataContextFactory>().As<IDataContextFactory>()
                .InstancePerDependency();
        }
    }
}