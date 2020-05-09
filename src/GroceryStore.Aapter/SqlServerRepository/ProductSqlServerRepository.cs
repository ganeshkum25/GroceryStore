using System;
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

        public async Task<Guid> Save(Product product)
        {
            await _products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<Product> Get(Guid productId)
        {
            return await _products.FirstOrDefaultAsync(product => product.ProductId == productId).ConfigureAwait(false);
        }
    }
}