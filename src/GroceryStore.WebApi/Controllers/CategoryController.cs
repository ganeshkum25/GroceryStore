using System;
using GroceryStore.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public Category GetCategory(string categoryId)
        {
            return null;
        }
    }
}