using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.TestimonialDtos;
using RoyalEstateDapperProject.Services.Testimonial;
using RoyalEstateDapperProject.Validation.TestimonialDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _testimonialService.GetAllTestimonialAsync());
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            CreateTestimonialDtoValidator validationRules = new CreateTestimonialDtoValidator();
            ValidationResult result = validationRules.Validate(createTestimonialDto);
            if (result.IsValid)
            {
                await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createTestimonialDto);
            }
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            return View(await _testimonialService.GetByIdTestimonialAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            UpdateTestimonialDtoValidator validator = new UpdateTestimonialDtoValidator();
            ValidationResult result = validator.Validate(updateTestimonialDto);
            if(result.IsValid)
            {
                await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
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
