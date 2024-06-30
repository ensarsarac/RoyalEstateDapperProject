using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstateDapperProject.Dtos.PropertyDtos;
using RoyalEstateDapperProject.Services.Category;
using RoyalEstateDapperProject.Services.Location;
using RoyalEstateDapperProject.Services.Property;
using RoyalEstateDapperProject.Validation.PropertyDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private readonly IProperyService _properyService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;

        public PropertyController(IProperyService properyService, ILocationService locationService, ICategoryService categoryService)
        {
            _properyService = properyService;
            _locationService = locationService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _properyService.GetAllPropertyCategoryAndLocationAsync());
        }
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _properyService.DeletePropertyAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateProperty()
        {
            ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
            ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyDto createPropertyDto)
        {
            createPropertyDto.IsRecent = false;
            CreatePropertyDtoValidator validationRules = new CreatePropertyDtoValidator();
            ValidationResult result = validationRules.Validate(createPropertyDto);
            if (result.IsValid)
            {
                await _properyService.CreatePropertyAsync(createPropertyDto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
                ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }
        public async Task<IActionResult> UpdateProperty(int id)
        {
            ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
            ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
            return View(await _properyService.GetByIdPropertyAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProperty(UpdatePropertyDto updatePropertyDto)
        {
            UpdatePropertyDtoValidator validationRules = new UpdatePropertyDtoValidator();
            ValidationResult result = validationRules.Validate(updatePropertyDto);
            if(result.IsValid)
            {
                await _properyService.UpdatePropertyAsync(updatePropertyDto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = new SelectList(await _categoryService.GetAllCategoryAsync(), "CategoryId", "CategoryName");
                ViewBag.locations = new SelectList(await _locationService.GetAllLocationAsync(), "LocationId", "Location");
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
        public async Task<IActionResult> FeaturePropertyTrue(int id)
        {
            await _properyService.FeaturePropertiesTrue(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> FeaturePropertyFalse(int id)
        {
            await _properyService.FeaturePropertiesFalse(id);
            return RedirectToAction("Index");
        }
    }
}
