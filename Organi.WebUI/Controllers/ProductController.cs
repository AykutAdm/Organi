using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organi.WebUI.DTOs.ProductDtos;
using Organi.WebUI.DTOs.CategoryDtos;

namespace Organi.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.GetAsync("https://localhost:7231/api/Products");
            var categoryResponse = await client.GetAsync("https://localhost:7231/api/Categories");
            
            if (responseMessage.IsSuccessStatusCode && categoryResponse.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
                
                ViewBag.Categories = categories;
                return View(products);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FilterProducts(int? categoryId, decimal? minPrice, decimal? maxPrice, string searchTerm)
        {
            var client = _httpClientFactory.CreateClient();
            
            var url = "https://localhost:7231/api/Products/GetAllProductsByFilter?";
            if (categoryId.HasValue) url += $"categoryId={categoryId}&";
            if (minPrice.HasValue) url += $"minPrice={minPrice}&";
            if (maxPrice.HasValue) url += $"maxPrice={maxPrice}&";
            if (!string.IsNullOrEmpty(searchTerm)) url += $"searchTerm={searchTerm}&";
            
            var responseMessage = await client.GetAsync(url);
            var categoryResponse = await client.GetAsync("https://localhost:7231/api/Categories");
            
            if (responseMessage.IsSuccessStatusCode && categoryResponse.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
                
                ViewBag.Categories = categories;
                return View("Index", products);
            }
            return View("Index");
        }
    }
}
