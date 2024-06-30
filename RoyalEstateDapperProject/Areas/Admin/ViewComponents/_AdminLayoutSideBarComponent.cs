using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Areas.Admin.ViewComponents
{
	public class _AdminLayoutSideBarComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
