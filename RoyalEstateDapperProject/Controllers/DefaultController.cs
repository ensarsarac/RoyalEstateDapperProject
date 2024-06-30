using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
