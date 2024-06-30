using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.FeaturesDtos;
using RoyalEstateDapperProject.Services.Features;
using RoyalEstateDapperProject.Validation.FeaturesDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturesController : Controller
    {
        private readonly IFeaturesService _featuresService;

        public FeaturesController(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _featuresService.GetAllFeaturesAsync());
        }
        public async Task<IActionResult> DeleteFeatures(int id)
        {
            await _featuresService.DeleteFeaturesAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateFeatures()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatures(CreateFeaturesDto createFeaturesDto)
        {
            CreateFeaturesDtoValidator validationRules = new CreateFeaturesDtoValidator();
            ValidationResult result = validationRules.Validate(createFeaturesDto);
            if(result.IsValid)
            {
                await _featuresService.CreateFeaturesAsync(createFeaturesDto);
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
        public async Task<IActionResult> UpdateFeatures(int id)
        {
            return View(await _featuresService.GetByIdFeaturesAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatures(UpdateFeaturesDto updateFeaturesDto)
        {
            UpdateFeaturesDtoValidator validationRules=new UpdateFeaturesDtoValidator();
            ValidationResult result = validationRules.Validate(updateFeaturesDto);
            if(result.IsValid )
            {
                await _featuresService.UpdateFeaturesAsync(updateFeaturesDto);
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
