using System;
using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class MessageEntityTypeConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Method)
                .HasMaxLength(50)
                .HasConversion(x => x.ToString(),
                    x => (MethodEntity) Enum.Parse(typeof(MethodEntity), x));

            builder.Property(x => x.From)
                .HasMaxLength(50)
                .HasConversion(x => x.ToString(),
                    x => (DirectionEntity) Enum.Parse(typeof(DirectionEntity), x));

            builder.Property(x => x.To)
                .HasMaxLength(50)
                .HasConversion(x => x.ToString(),
                    x => (DirectionEntity) Enum.Parse(typeof(DirectionEntity), x));

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}