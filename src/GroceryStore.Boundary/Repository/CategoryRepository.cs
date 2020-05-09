using System;
using System.Threading.Tasks;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface CategoryRepository
    {
        Task<Guid> Save(Category product);

        Task<Category> Get(Guid productId);
    }
}