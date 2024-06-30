using Microsoft.AspNetCore.Mvc;

namespace RoyalEstateDapperProject.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
