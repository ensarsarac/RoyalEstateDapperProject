using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Areas.Admin.ViewComponents
{
	public class _AdminLayoutTopBarComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
