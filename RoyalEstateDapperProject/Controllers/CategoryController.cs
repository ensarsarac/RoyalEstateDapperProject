using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;

namespace RoyalEstateDapperProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProperyService _propertyService;

        public CategoryController(IProperyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index(int id)
        {
            return View(await _propertyService.GetAllPropertyByCategoryIdAsync(id));
        }
    }
}
