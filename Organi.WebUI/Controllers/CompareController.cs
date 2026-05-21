using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organi.WebUI.DTOs.ProductDtos;
using Organi.WebUI.DTOs.ProductNutritionDtos;
using System.Threading.Tasks;

namespace Organi.WebUI.Controllers
{
    public class CompareController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CompareController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

  
            var productResponse = await client.GetAsync("https://localhost:7231/api/Products");
            var jsonData = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);


            var nutritionResponse = await client.GetAsync("https://localhost:7231/api/ProductNutritions");
            var jsonData2 = await nutritionResponse.Content.ReadAsStringAsync();
            var nutritions = JsonConvert.DeserializeObject<List<ResultProductNutritionDto>>(jsonData2);

            ViewBag.Products = products;
            ViewBag.Nutritions = nutritions;

            return View();
        }
    }
}
