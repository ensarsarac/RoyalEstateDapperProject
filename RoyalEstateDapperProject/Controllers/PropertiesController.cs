using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Models;
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

        public async Task<IActionResult> Index(SearchPropertyViewModel? model, int page=1,int pageSize=6)
        {
            if(!string.IsNullOrEmpty(model.Location) || !string.IsNullOrEmpty(model.PropertyStatus))
            {
                var values = await _propertyService.GetAllPropertyByFilterAsync(model);
                var result = values.ToPagedList(page,pageSize);
                return View(result);
            }
            else
            {
                var values = await _propertyService.GetAllPropertyCategoryAndLocationAsync();
                var result = values.ToPagedList(page, pageSize);
                return View(result);
            }

            
        }
        public async Task<IActionResult> Details(int id)
        {

            return View(id);
        }

    }
}
