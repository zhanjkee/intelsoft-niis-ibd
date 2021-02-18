using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class ContractRequestEntityTypeConfiguration : IEntityTypeConfiguration<ContractRequestEntity>
    {
        public void Configure(EntityTypeBuilder<ContractRequestEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Property)
                .WithOne()
                .HasForeignKey<ContractRequestEntity>(x => x.PropertyId);

            builder.HasOne(x => x.Type)
                .WithOne()
                .HasForeignKey<ContractRequestEntity>(x => x.TypeId);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}