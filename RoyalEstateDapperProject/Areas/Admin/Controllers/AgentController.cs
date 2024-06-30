using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.AgentDtos;
using RoyalEstateDapperProject.Services.Agent;
using RoyalEstateDapperProject.Validation.AgentDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _agentService.GetAllAgentAsync());
        }
        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _agentService.DeleteAgentAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentDto createAgentDto)
        {
            CreateAgentDtoValidator validationRules = new CreateAgentDtoValidator();
            ValidationResult result = validationRules.Validate(createAgentDto);
            if (result.IsValid)
            {
                await _agentService.CreateAgentAsync(createAgentDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createAgentDto);
            }
        }
        public async Task<IActionResult> UpdateAgent(int id)
        {
            return View(await _agentService.GetByIdAgentAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAgent(UpdateAgentDto updateAgentDto)
        {
            UpdateAgentDtoValidator validationRules = new UpdateAgentDtoValidator();
            ValidationResult result = validationRules.Validate(updateAgentDto);
            if(result.IsValid) {
                await _agentService.UpdateAgentAsync(updateAgentDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }
    }
}
