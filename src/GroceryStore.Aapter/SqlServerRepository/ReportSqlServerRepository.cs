using System.Collections.Generic;
using System.Linq;
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
            var productWithCategories = _sqlServerDbContext.Products.GroupJoin(_sqlServerDbContext.Categories, product => product.CategoryId, category => category.ID,
                (product, category) =>
                    new ProductWithCategory()
                    {
                        ID = product.ID,
                        Name = product.Name,
                        CategoryId = product.CategoryId,
                        Category = category.FirstOrDefault()
                    });
            return Task.FromResult<IEnumerable<ProductWithCategory>>(productWithCategories);
        }
    }
}