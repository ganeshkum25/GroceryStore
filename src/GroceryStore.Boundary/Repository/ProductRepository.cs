using System.Threading.Tasks;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface ProductRepository
    {
        Task<string> Save(Product product);

        Task<Product> Get(string productId);
    }
}