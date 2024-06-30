using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.ViewComponents._UILayoutComponents
{
    public class _UILayoutLoaderComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
