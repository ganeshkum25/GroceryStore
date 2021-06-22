using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReportController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult<ProductWithCategory[]>> Get(int pageIndex, int elementsPerPage)
        {
            var data1 = new ProductWithCategory() { ID = "123", Category = new Category() { ID = "123", Name = "Upawas" }, Name = "Shabu", CategoryId = "123" };
            var data2 = new ProductWithCategory() { ID = "123", Category = new Category() { ID = "123", Name = "Upawas" }, Name = "Potato Chips", CategoryId = "123" };
            var list = new List<ProductWithCategory>() { data1, data2 };
            return Task.FromResult(new ActionResult<ProductWithCategory[]>(list.ToArray()));
        }
    }
}