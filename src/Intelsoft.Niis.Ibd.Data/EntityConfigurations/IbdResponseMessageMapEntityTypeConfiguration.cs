using Intelsoft.Niis.Ibd.Entities.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    internal class IbdResponseMessageMapEntityTypeConfiguration : IEntityTypeConfiguration<IbdResponseMessageMapEntity>
    {
        public void Configure(EntityTypeBuilder<IbdResponseMessageMapEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasKey(x => new {x.IbdResponseId, x.MessageId});

            builder.HasOne(x => x.IbdResponse)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.IbdResponseId);

            builder.HasOne(x => x.Message)
                .WithMany(x => x.IbdResponses)
                .HasForeignKey(x => x.MessageId);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}