using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class ContractRequestDispatchStatusEntityTypeConfiguration : EntityBaseTypeConfiguration<ContractRequestDispatchStatusEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ContractRequestDispatchStatusEntity> builder)
        {
            builder.HasOne(x => x.ContractRequest)
                .WithOne()
                .HasForeignKey<ContractRequestDispatchStatusEntity>(x => x.ContractRequestId);
        }
    }
}
