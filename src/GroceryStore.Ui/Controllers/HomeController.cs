using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using GroceryStore.Sdk;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GroceryStore.Ui.Models;

namespace GroceryStore.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _apiClient = new HttpClient();
        public HomeController(ILogger<HomeController> logger,
            string serviceConnectionString)
        {
            _logger = logger;
            _apiClient.BaseAddress = new Uri(serviceConnectionString);
        }

        public async Task<IActionResult> Index()
        {
            var data = await GetReportingData(0, 0);
            return View();
        }

        public async Task<List<ProductWithCategory>> GetProductsWithCategory(int pageIndex, int elementsPerPage)
        {
            return await GetReportingData(pageIndex, elementsPerPage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<List<ProductWithCategory>> GetReportingData(int pageIndex, int elementsPerPage)
        {
            var response = await _apiClient.GetAsync($"{pageIndex}{elementsPerPage}");
            if (!response.IsSuccessStatusCode)
            {
                Redirect("Error");
            }

            var str = await response.Content.ReadAsStringAsync();
            return null;
        }
    }
}
