using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutBackToTopComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
