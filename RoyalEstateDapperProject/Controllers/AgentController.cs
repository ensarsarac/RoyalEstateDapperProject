using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Agent;

namespace RoyalEstateDapperProject.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _agentService.GetAllAgentAsync();
            return View(values);
        }
    }
}
