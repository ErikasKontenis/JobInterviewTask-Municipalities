using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Municipalities.Core.Extensions;

namespace Municipalities.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void PluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = InflectorExtensions.Pluralize(entity.DisplayName());
            }
        }
    }
}