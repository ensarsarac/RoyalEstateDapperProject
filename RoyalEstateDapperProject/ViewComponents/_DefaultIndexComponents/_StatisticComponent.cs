using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;

namespace RoyalEstateDapperProject.ViewComponents._DefaultIndexComponents
{
    public class _StatisticComponent:ViewComponent
    {
        private readonly IProperyService _properyService;

        public _StatisticComponent(IProperyService properyService)
        {
            _properyService = properyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.testimonialcount = await _properyService.GetTestimonialCount();
            ViewBag.propertiescount = await _properyService.GetPropertyCount();
            ViewBag.agentcount = await _properyService.GetAgentCount();
            ViewBag.maxcategoryname = await _properyService.GetMaxProperyCategory();
            return View();
        }
    }
}
