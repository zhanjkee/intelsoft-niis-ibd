using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Maps;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext([NotNull] DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<ContractRequestEntity> ContractRequests { get; set; }
        public DbSet<ContractTypeEntity> ContractTypes { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }
        public DbSet<ContractRequestDispatchStatusEntity> ContractRequestDispatchStatuses { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<IbdResponseEntity> IbdResponses { get; set; }
        public DbSet<ContractRequestMessageMapEntity> ContractRequestMessageMap { get; set; }
        public DbSet<IbdResponseMessageMapEntity> IbdResponseMessageMap { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}