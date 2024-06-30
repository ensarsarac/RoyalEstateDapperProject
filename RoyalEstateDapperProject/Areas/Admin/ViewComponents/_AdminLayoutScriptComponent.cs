using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Areas.Admin.ViewComponents
{
	public class _AdminLayoutScriptComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
