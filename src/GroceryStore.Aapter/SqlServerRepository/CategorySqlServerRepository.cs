using System;
using System.Threading.Tasks;
using GroceryStore.Boundary.Repository;
using GroceryStore.Sdk;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Adapter.SqlServerRepository
{
    public class CategorySqlServerRepository : CategoryRepository
    {
        private readonly SqlServerDbContext _dbContext;
        private readonly DbSet<Category> _categories;

        public CategorySqlServerRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
            _categories = dbContext.Categories;
        }

        public async Task<Guid> Save(Category category)
        {
            await _categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<Category> Get(Guid categoryId)
        {
            return 
                await _categories.FirstOrDefaultAsync(category => category.CategoryId == categoryId)
                .ConfigureAwait(false);
        }
    }
}