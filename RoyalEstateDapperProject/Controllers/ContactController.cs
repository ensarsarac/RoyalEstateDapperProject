using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
