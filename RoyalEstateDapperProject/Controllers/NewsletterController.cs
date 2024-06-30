using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Dtos.NewsletterDtos;
using RoyalEstateDapperProject.Services.Newsletter;
using RoyalEstateDapperProject.Services.SendMail;
using RoyalEstateDapperProject.Validation.NewsletterDtos;

namespace RoyalEstateDapperProject.Controllers
{
	public class NewsletterController : Controller
	{
		private readonly INewsletterService _newsletterService;
		private readonly ISendMailService _sendMailService;

        public NewsletterController(INewsletterService newsletterService, ISendMailService sendMailService)
        {
            _newsletterService = newsletterService;
            _sendMailService = sendMailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsletter(string email)
		{
			CreateNewsletterDto createNewsletterDto = new CreateNewsletterDto() { Email = email };
			CreateNewsletterDtoValidator validationRules = new CreateNewsletterDtoValidator();
			ValidationResult result = validationRules.Validate(createNewsletterDto);
			if (result.IsValid)
			{
				await _newsletterService.CreateNewsletterAsync(createNewsletterDto);
				_sendMailService.NewsletterSuccesMail(email);
				return NoContent();
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return BadRequest(createNewsletterDto);
			}
		}
	}
}
