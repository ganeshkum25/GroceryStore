using GroceryStore.Sdk;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Adapter.SqlServerRepository
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}