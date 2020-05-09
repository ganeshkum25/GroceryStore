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
        public Task<ProductWithCategory[]> Get(int pageIndex, int elementsPerPage)
        {
            return null;
        }
    }
}