using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.ViewComponents._UILayoutComponents
{
    public class _UILayoutHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
