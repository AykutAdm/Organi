using Microsoft.AspNetCore.Mvc;

namespace Organi.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultSalePromoComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
