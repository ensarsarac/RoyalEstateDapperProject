using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Models;

namespace RoyalEstateDapperProject.ViewComponents._UILayoutComponents
{
    public class _UILayoutSearchPropertyComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new SearchPropertyViewModel());
        }
    }
}
