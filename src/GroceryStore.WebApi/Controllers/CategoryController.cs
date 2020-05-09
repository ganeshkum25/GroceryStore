using System.Threading.Tasks;
using GroceryStore.Boundary.Repository;
using GroceryStore.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<string> Save(Category category)
        {
            return await _categoryRepository.Save(category);
        }

        [HttpGet]
        public async Task<Category> Get(string categoryId)
        {
            return await _categoryRepository.Get(categoryId);
        }
    }
}