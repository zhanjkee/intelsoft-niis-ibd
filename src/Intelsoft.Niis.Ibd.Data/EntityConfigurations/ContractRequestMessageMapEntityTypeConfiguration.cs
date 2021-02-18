using Intelsoft.Niis.Ibd.Entities.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    internal class
        ContractRequestMessageMapEntityTypeConfiguration : IEntityTypeConfiguration<ContractRequestMessageMapEntity>
    {
        public void Configure(EntityTypeBuilder<ContractRequestMessageMapEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasKey(x => new {x.ContractRequestId, x.MessageId});

            builder.HasOne(x => x.ContractRequest)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.ContractRequestId);

            builder.HasOne(x => x.Message)
                .WithMany(x => x.ContractRequests)
                .HasForeignKey(x => x.MessageId);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}