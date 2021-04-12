using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data
{
    public class NiisDbContext : DbContext
    {
        public NiisDbContext(DbContextOptions<NiisDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public virtual DbSet<NiisIbdContractEntity> NiisIbdContract { get; set; }
        public virtual DbSet<NiisIbdContractTypeEntity> NiisIbdContractTypes { get; set; }
        public virtual DbSet<NiisIbdPropertyEntity> NiisIbdProperty { get; set; }
    }
}
