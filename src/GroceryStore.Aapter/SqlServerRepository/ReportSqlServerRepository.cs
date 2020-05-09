using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStore.Boundary.Repository;
using GroceryStore.Sdk;

namespace GroceryStore.Adapter.SqlServerRepository
{
    public class ReportSqlServerRepository : ReportRepository
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public ReportSqlServerRepository(
            SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public Task<IEnumerable<ProductWithCategory>> GetProducts(int pageIndex,
            int elementsPerPage)
        {
            return null;
        }
    }
}