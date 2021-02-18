using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class PropertyEntityTypeConfiguration : IEntityTypeConfiguration<PropertyEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .HasConversion(x => (int) x,
                    x => (PropertyTypeEntity) x);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}