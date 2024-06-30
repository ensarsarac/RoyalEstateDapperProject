using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Areas.Admin.ViewComponents
{
	public class _AdminLayoutFooterComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
