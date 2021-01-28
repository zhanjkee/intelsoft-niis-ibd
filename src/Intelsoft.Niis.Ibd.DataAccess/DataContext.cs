using Intelsoft.Niis.Ibd.DataAccess.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext([NotNull] DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<ContractEntity> Contracts { get; set; }
        public DbSet<ContractTypeEntity> ContractTypes { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }
        public DbSet<ContractDispatchStatusEntity> ContractDispatchStatuses { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
