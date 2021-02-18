using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class
        ContractRequestDispatchStatusEntityTypeConfiguration : IEntityTypeConfiguration<
            ContractRequestDispatchStatusEntity>
    {
        public void Configure(EntityTypeBuilder<ContractRequestDispatchStatusEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ContractRequest)
                .WithOne()
                .HasForeignKey<ContractRequestDispatchStatusEntity>(x => x.ContractRequestId);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}