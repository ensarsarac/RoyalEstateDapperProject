using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.TagCloudDtos;
using RoyalEstateDapperProject.Services.Tag;
using RoyalEstateDapperProject.Validation.TagDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagCloudController : Controller
    {
        private readonly ITagService _tagService;

        public TagCloudController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tagService.GetAllTagAsync());
        }
        public IActionResult CreateTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
        {
            CreateTagDtoValidator validationRules = new CreateTagDtoValidator();
            ValidationResult result = validationRules.Validate(createTagDto);
            if (result.IsValid)
            {
                await _tagService.CreateTagAsync(createTagDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createTagDto);
            }
        }
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTagAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTag(int id)
        {

            return View(await _tagService.GetByIdTagAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTag(UpdateTagDto updateTagDto)
        {
            UpdateTagDtoValidator validationRules = new UpdateTagDtoValidator();
            ValidationResult result = validationRules.Validate(updateTagDto);
            if (result.IsValid)
            {
                await _tagService.UpdateTagAsync(updateTagDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }
    }
}
