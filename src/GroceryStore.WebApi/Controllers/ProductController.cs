using System.Threading.Tasks;
using GroceryStore.Boundary.Repository;
using GroceryStore.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<string> Save(Product product)
        {
            return await _productRepository.Save(product);
        }

        [HttpGet]
        public async Task<Product> Get(string productId)
        {
            return await _productRepository.Get(productId);
        }
    }
}