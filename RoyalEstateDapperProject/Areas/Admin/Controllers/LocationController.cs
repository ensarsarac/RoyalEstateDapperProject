using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.LocationDtos;
using RoyalEstateDapperProject.Services.Location;
using RoyalEstateDapperProject.Validation.LocationDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _locationService.GetAllLocationAsync());
        }
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            CreateLocationDtoValidator validationRules = new CreateLocationDtoValidator();
            ValidationResult result = validationRules.Validate(createLocationDto);
            if (result.IsValid)
            {
                await _locationService.CreateLocationAsync(createLocationDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createLocationDto);
            }
            
        }
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateLocation(int id)
        {
            return View(await _locationService.GetByIdLocationAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            UpdateLocationDtoValidator validationRules = new UpdateLocationDtoValidator();
            ValidationResult result = validationRules.Validate(updateLocationDto);
            if (result.IsValid)
            {
                await _locationService.UpdateLocationAsync(updateLocationDto);
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
