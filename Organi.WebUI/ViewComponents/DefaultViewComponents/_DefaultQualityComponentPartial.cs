using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultQualityComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
