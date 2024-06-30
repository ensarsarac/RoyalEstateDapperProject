using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.ViewComponents._UILayoutComponents
{
    public class _UILayoutHeroComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
