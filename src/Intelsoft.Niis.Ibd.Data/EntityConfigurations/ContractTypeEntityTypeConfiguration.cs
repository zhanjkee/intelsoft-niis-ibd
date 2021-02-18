using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    internal class ContractTypeEntityTypeConfiguration : IEntityTypeConfiguration<ContractTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ContractTypeEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}