using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
