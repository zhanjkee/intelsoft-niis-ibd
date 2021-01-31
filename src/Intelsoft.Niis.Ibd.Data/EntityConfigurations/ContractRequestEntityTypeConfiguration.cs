using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class ContractRequestEntityTypeConfiguration : EntityBaseTypeConfiguration<ContractRequestEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ContractRequestEntity> builder)
        {
            builder.HasOne(x => x.Property)
                .WithOne()
                .HasForeignKey<ContractRequestEntity>(x => x.PropertyId);

            builder.HasOne(x => x.Type)
                .WithOne()
                .HasForeignKey<ContractRequestEntity>(x => x.TypeId);
        }
    }
}
