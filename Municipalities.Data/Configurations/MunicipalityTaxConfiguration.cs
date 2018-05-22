using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Municipalities.Domain.Municipalities;

namespace Municipalities.Data.Configurations
{
    public class MunicipalityTaxConfiguration : IEntityTypeConfiguration<MunicipalityTax>
    {
        public void Configure(EntityTypeBuilder<MunicipalityTax> entity)
        {
            entity.HasKey(o => new { o.Id });

            entity.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            entity.HasOne(o => o.Municipality)
                .WithMany(o => o.MunicipalityTaxes)
                .HasForeignKey(o => o.MunicipalityId);
        }
    }
}
