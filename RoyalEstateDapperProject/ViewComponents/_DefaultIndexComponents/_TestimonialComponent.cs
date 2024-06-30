using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Testimonial;

namespace RoyalEstateDapperProject.ViewComponents._DefaultIndexComponents
{
	public class _TestimonialComponent:ViewComponent
	{
		private readonly ITestimonialService _testimonialService;

		public _TestimonialComponent(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await _testimonialService.GetAllTestimonialAsync());
		}
	}
}
