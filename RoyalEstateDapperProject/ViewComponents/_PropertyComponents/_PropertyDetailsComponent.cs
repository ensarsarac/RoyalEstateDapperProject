using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;

namespace RoyalEstateDapperProject.ViewComponents._PropertyComponents
{
    public class _PropertyDetailsComponent:ViewComponent
    {
        private readonly IProperyService _propertyService;

        public _PropertyDetailsComponent(IProperyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _propertyService.GetByIdPropertyWithIncludeAsync(id);
            return View(value);
        }
    }
}
