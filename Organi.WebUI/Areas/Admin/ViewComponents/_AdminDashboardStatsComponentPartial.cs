using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organi.WebUI.DTOs.DashboardDtos;
using System.Threading.Tasks;

namespace Organi.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminDashboardStatsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7231/api/Dashboard/GetStats");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultDashboardStatsDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
