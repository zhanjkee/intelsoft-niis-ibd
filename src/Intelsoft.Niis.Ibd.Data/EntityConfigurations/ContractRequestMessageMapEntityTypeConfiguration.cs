using Intelsoft.Niis.Ibd.Entities.Maps;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    internal class ContractRequestMessageMapEntityTypeConfiguration : EntityBaseTypeConfiguration<ContractRequestMessageMapEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ContractRequestMessageMapEntity> builder)
        {
            builder.HasKey(x => new { x.ContractRequestId, x.MessageId });

            builder.HasOne(x => x.ContractRequest)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.ContractRequestId);

            builder.HasOne(x => x.Message)
                .WithMany(x => x.ContractRequests)
                .HasForeignKey(x => x.MessageId);
        }
    }
}
