using Municipalities.Data.DbContexts;

namespace Municipalities.Tests
{
    public class TestUtil
    {
        public static MunicipalityDbContext DbContext => new MunicipalityDbContext();
    }
}
