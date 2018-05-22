using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Municipalities.Domain.Municipalities;

namespace Municipalities.Data.Configurations
{
    public class MunicipalityConfiguration : IEntityTypeConfiguration<Municipality>
    {
        public void Configure(EntityTypeBuilder<Municipality> entity)
        {
            entity.HasKey(o => new { o.Id });

            entity.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(o => o.Name);

            entity.HasMany(o => o.MunicipalityTaxes)
                .WithOne(o => o.Municipality)
                .HasForeignKey(o => o.MunicipalityId);
        }
    }
}
