using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
