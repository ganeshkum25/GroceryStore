using System;
using System.Threading.Tasks;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface ProductRepository
    {
        Task<Guid> Save(Product product);

        Task<Product> Get(Guid productId);
    }
}