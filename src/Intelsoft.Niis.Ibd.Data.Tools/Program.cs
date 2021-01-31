using System;
using System.Threading.Tasks;
using Autofac;
using Intelsoft.Niis.Ibd.Configuration;
using Intelsoft.Niis.Ibd.Data.Autofac;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data.Tools
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Database migration is running.");

            try
            {
                var builder = new ContainerBuilder();
                builder.Register(x => NiisIbdSettingsReader.Read())
                    .SingleInstance()
                    .AsSelf()
                    .AutoActivate();
                builder.RegisterModule<DataModule>();
                var container = builder.Build();

                var options = container.Resolve<DbContextOptions<DataContext>>();
                var context = new DataContext(options);
                await context.Database.MigrateAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }

            Console.WriteLine("Database migration completed.");

            // Delay.
            Console.ReadKey();
        }
    }
}
