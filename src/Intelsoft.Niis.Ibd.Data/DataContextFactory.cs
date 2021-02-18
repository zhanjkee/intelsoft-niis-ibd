using System;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data
{
    public class DataContextFactory : IDataContextFactory
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;

        public DataContextFactory([NotNull] DbContextOptions<DataContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }

        public IDataContext Create()
        {
            var context = new DataContext(_dbContextOptions);

            var migrations = context.Database.GetPendingMigrations();
            if (migrations == null) return context;

            context.Database.Migrate();

            return context;
        }
    }
}