using Intelsoft.Niis.Ibd.Entities;
using Intelsoft.Niis.Ibd.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class PropertyEntityTypeConfiguration : EntityBaseTypeConfiguration<PropertyEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder.Property(x => x.Type)
                .HasConversion(x => (int)x,
                    x => (PropertyType)x);
        }
    }
}
