using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutQuickViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
