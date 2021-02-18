using Intelsoft.Niis.Ibd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelsoft.Niis.Ibd.Data.EntityConfigurations
{
    public class IbdResponseEntityTypeConfiguration : IEntityTypeConfiguration<IbdResponseEntity>
    {
        public void Configure(EntityTypeBuilder<IbdResponseEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
        }
    }
}