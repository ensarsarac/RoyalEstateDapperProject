using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Tag;

namespace RoyalEstateDapperProject.ViewComponents._PropertyComponents
{
    public class _PropertyDetailsTagCloudComponent:ViewComponent
    {
        private readonly ITagService _tagService;

        public _PropertyDetailsTagCloudComponent(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _tagService.GetAllTagAsync());  
        }
    }
}
