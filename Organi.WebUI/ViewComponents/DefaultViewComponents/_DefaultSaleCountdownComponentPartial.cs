using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultSaleCountdownComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
