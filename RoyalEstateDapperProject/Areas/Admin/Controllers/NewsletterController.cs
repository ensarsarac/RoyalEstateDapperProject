using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.NewsletterDtos;
using RoyalEstateDapperProject.Services.Newsletter;
using RoyalEstateDapperProject.Validation.NewsletterDtos;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsletterController : Controller
	{
		private readonly INewsletterService _newsletterService;

		public NewsletterController(INewsletterService newsletterService)
		{
			_newsletterService = newsletterService;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _newsletterService.GetAllNewsletterAsync());
		}
		public async Task<IActionResult> DeleteNewsletter(int id)
		{
			await _newsletterService.DeleteNewsletterAsync(id);
			return RedirectToAction("Index");
		}
		public IActionResult CreateNewsletter()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNewsletter(CreateNewsletterDto createNewsletterDto)
		{
			CreateNewsletterDtoValidator validationRules = new CreateNewsletterDtoValidator();
			ValidationResult result = validationRules.Validate(createNewsletterDto);
			if (result.IsValid)
			{
				await _newsletterService.CreateNewsletterAsync(createNewsletterDto);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(createNewsletterDto);
			}
		}
		public async Task<IActionResult> UpdateNewsletter(int id)
		{
			return View(await _newsletterService.GetByIdNewsletterAsync(id));
		}
		[HttpPost]
		public async Task<IActionResult> UpdateNewsletter(UpdateNewsletterDto updateNewsletterDto)
		{
			UpdateNewsletterDtoValidator validationRules = new UpdateNewsletterDtoValidator();
			ValidationResult result = validationRules.Validate(updateNewsletterDto);
			if (result.IsValid)
			{
				await _newsletterService.UpdateNewsletterAsync(updateNewsletterDto);
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
