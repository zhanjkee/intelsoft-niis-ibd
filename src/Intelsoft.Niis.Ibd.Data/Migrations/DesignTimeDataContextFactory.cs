using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Intelsoft.Niis.Ibd.Data.Migrations
{
    internal sealed class DesignTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? "Server=(local);Database=niis_ibd;Trusted_Connection=True;";

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(nameof(connectionString));

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(DataContext).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30),
                            null);
                    });
            var dbContextOptions = dbContextOptionsBuilder.Options;
            
            return new DataContext(dbContextOptions);
        }
    }
}
