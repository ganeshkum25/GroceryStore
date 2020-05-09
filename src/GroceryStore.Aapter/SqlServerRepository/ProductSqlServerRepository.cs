using System.Threading.Tasks;
using GroceryStore.Boundary.Repository;
using GroceryStore.Sdk;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Adapter.SqlServerRepository
{
    public class ProductSqlServerRepository : ProductRepository
    {
        private readonly SqlServerDbContext _dbContext;
        private DbSet<Product> _products;

        public ProductSqlServerRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
            _products = dbContext.Products;
        }

        public async Task<string> Save(Product product)
        {
            await _products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.ID;
        }

        public async Task<Product> Get(string productId)
        {
            return await _products.FirstOrDefaultAsync(product => product.ID == productId).ConfigureAwait(false);
        }
    }
}