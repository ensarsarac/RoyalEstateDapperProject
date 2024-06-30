using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;

namespace RoyalEstateDapperProject.ViewComponents._DefaultIndexComponents
{
    public class _SliderComponent:ViewComponent
    {
        private readonly IProperyService _propertyService;

        public _SliderComponent(IProperyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _propertyService.GetLast5PropertyListAsync());
        }
    }
}
