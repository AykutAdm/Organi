using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organi.WebUI.DTOs.ProductDtos;
using Organi.WebUI.DTOs.ProductNutritionDtos;
using System.Text;

namespace Organi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductNutrition")]
    public class ProductNutritionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductNutritionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductNutritionList")]
        public async Task<IActionResult> ProductNutritionList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7231/api/ProductNutritions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductNutritionDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateProductNutrition")]
        public async Task<IActionResult> CreateProductNutrition()
        {
            var client = _httpClientFactory.CreateClient();
            var productResponse = await client.GetAsync("https://localhost:7231/api/Products");
            var products = new List<ResultProductDto>();
            if (productResponse.IsSuccessStatusCode)
            {
                var jsonData = await productResponse.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            }
            ViewBag.Products = products;
            return View(new CreateProductNutritionDto());
        }

        [HttpPost]
        [Route("CreateProductNutrition")]
        public async Task<IActionResult> CreateProductNutrition(CreateProductNutritionDto createProductNutritionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductNutritionDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7231/api/ProductNutritions", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductNutritionList", new { area = "Admin" });
            }
            var productResponse = await client.GetAsync("https://localhost:7231/api/Products");
            var products = new List<ResultProductDto>();
            if (productResponse.IsSuccessStatusCode)
            {
                var productData = await productResponse.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);
            }
            ViewBag.Products = products;
            return View(createProductNutritionDto);
        }

        [HttpGet]
        [Route("UpdateProductNutrition/{id}")]
        public async Task<IActionResult> UpdateProductNutrition(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7231/api/ProductNutritions/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductNutritionDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("ProductNutritionList", new { area = "Admin" });
        }

        [HttpPost]
        [Route("UpdateProductNutrition")]
        public async Task<IActionResult> UpdateProductNutrition(UpdateProductNutritionDto updateProductNutritionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductNutritionDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7231/api/ProductNutritions", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductNutritionList", new { area = "Admin" });
            }
            return View(updateProductNutritionDto);
        }

        [Route("DeleteProductNutrition/{id}")]
        public async Task<IActionResult> DeleteProductNutrition(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7231/api/ProductNutritions/{id}");
            return RedirectToAction("ProductNutritionList", new { area = "Admin" });
        }
    }
}
