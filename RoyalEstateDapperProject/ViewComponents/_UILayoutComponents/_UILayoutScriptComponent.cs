using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.ViewComponents._UILayoutComponents
{
    public class _UILayoutScriptComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
