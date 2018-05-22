using Microsoft.EntityFrameworkCore;
using Municipalities.Data.Configurations;
using Municipalities.Data.Extensions;
using Municipalities.Domain.Municipalities;

namespace Municipalities.Data.DbContexts
{
    public class MunicipalityDbContext : DbContext
    {
        public MunicipalityDbContext()
        { }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<MunicipalityTax> MunicipalityTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=root;password=;database=Municipalities;CharSet=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelBuilderExtensions.PluralizingTableNameConvention(modelBuilder);

            modelBuilder.ApplyConfiguration(new MunicipalityConfiguration());
            modelBuilder.ApplyConfiguration(new MunicipalityTaxConfiguration());
        }
    }
}
