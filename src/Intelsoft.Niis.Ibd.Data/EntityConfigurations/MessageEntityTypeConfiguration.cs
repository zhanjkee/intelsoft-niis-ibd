using System;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class MessageEntityTypeConfiguration : EntityBaseTypeConfiguration<MessageEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.Property(x => x.Method)
                .HasConversion(x => x.ToString(),
                    x => (MethodEntity)Enum.Parse(typeof(MethodEntity), x));

            builder.Property(x => x.From)
                .HasConversion(x => x.ToString(),
                    x => (DirectionEntity)Enum.Parse(typeof(DirectionEntity), x));

            builder.Property(x => x.To)
                .HasConversion(x => x.ToString(),
                    x => (DirectionEntity)Enum.Parse(typeof(DirectionEntity), x));
        }
    }
}
