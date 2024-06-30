using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.CategoryDtos;
using RoyalEstateDapperProject.Services.Category;
using RoyalEstateDapperProject.Validation.CategoryDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
		{
			return View(await _categoryService.GetAllCategoryAsync());
		}
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			CreateCategoryDtoValidator validationRules = new CreateCategoryDtoValidator();
			ValidationResult result = validationRules.Validate(createCategoryDto);
			if (result.IsValid)
			{
                await _categoryService.CreateCategoryAsync(createCategoryDto);
                return RedirectToAction("Index");
            }
            else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(createCategoryDto);
			}
		}
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }
		public async Task<IActionResult> UpdateCategory(int id)
		{
			
			return View(await _categoryService.GetByIdCategoryAsync(id));
		}
		[HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            UpdateCategoryDtoValidator validationRules = new UpdateCategoryDtoValidator();
            ValidationResult result = validationRules.Validate(updateCategoryDto);
			if(result.IsValid)
			{
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
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
