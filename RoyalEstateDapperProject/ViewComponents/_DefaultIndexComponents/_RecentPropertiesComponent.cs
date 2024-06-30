using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;

namespace RoyalEstateDapperProject.ViewComponents._DefaultIndexComponents
{
    public class _RecentPropertiesComponent:ViewComponent
    {
        private readonly IProperyService _service;

        public _RecentPropertiesComponent(IProperyService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _service.GetRecentPropertiesList();
            return View(values);
        }
    }
}
