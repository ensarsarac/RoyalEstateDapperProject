using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Category;

namespace RoyalEstateDapperProject.ViewComponents._PropertyComponents
{
    public class _PropertyDetailsCategoriesComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _PropertyDetailsCategoriesComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _categoryService.GetCategoryNameAndCount());
        }
    }
}
