using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultInstagramComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
