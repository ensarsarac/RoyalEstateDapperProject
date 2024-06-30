using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;
using X.PagedList;

namespace RoyalEstateDapperProject.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IProperyService _propertyService;

        public PropertiesController(IProperyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index(int page=1,int pageSize=6)
        {
            var values = await _propertyService.GetAllPropertyCategoryAndLocationAsync();
            var result = values.ToPagedList(page,pageSize);
            return View(result);
        }
    }
}
