using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organi.WebUI.DTOs.SliderDtos;
using System.Text;

namespace Organi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Slider")]
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("SliderList")]
        public async Task<IActionResult> SliderList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7231/api/Sliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateSlider")]
        public IActionResult CreateSlider()
        {
            return View(new CreateSliderDto());
        }

        [HttpPost]
        [Route("CreateSlider")]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7231/api/Sliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList", new { area = "Admin" });
            }
            return View(createSliderDto);
        }

        [HttpGet]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7231/api/Sliders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("SliderList", new { area = "Admin" });
        }

        [HttpPost]
        [Route("UpdateSlider")]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7231/api/Sliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList", new { area = "Admin" });
            }
            return View(updateSliderDto);
        }

        [Route("DeleteSlider/{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7231/api/Sliders/{id}");
            return RedirectToAction("SliderList", new { area = "Admin" });
        }
    }
}
