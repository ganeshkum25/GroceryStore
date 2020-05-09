using System.Threading.Tasks;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface CategoryRepository
    {
        Task<string> Save(Category category);

        Task<Category> Get(string categoryId);
    }
}