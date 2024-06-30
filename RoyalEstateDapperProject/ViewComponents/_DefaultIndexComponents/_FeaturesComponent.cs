using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Features;

namespace RoyalEstateDapperProject.ViewComponents._DefaultIndexComponents
{
    public class _FeaturesComponent:ViewComponent
    {
        private readonly IFeaturesService _featuresService;

        public _FeaturesComponent(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _featuresService.GetAllFeaturesAsync());
        }
    }
}
