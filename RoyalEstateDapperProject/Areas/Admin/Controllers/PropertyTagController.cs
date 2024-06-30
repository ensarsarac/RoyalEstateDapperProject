using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;
using RoyalEstateDapperProject.Services.Tag;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    public class PropertyTagController : Controller
    {
        private readonly IProperyService _propertyService;
        private readonly ITagService _tagService;
        public PropertyTagController(IProperyService propertyService, ITagService tagService)
        {
            _propertyService = propertyService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int id)
        {
            return View();
        }
    }
}
