using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Areas.Admin.ViewComponents
{
	public class _AdminLayoutHeadComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
