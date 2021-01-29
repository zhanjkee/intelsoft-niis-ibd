using Intelsoft.Niis.Ibd.Entities.Maps;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    internal class IbdResponseMessageMapEntityTypeConfiguration : EntityBaseTypeConfiguration<IbdResponseMessageMapEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<IbdResponseMessageMapEntity> builder)
        {
            builder.HasKey(x => new { x.IbdResponseId, x.MessageId });

            builder.HasOne(x => x.IbdResponse)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.IbdResponseId);

            builder.HasOne(x => x.Message)
                .WithMany(x => x.IbdResponses)
                .HasForeignKey(x => x.MessageId);
        }
    }
}
