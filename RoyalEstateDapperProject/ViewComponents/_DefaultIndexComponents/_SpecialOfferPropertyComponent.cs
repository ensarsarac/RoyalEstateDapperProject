using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.Property;

namespace RoyalEstateDapperProject.ViewComponents._DefaultIndexComponents
{
	public class _SpecialOfferPropertyComponent:ViewComponent
	{
		private readonly IProperyService _properyService;

		public _SpecialOfferPropertyComponent(IProperyService properyService)
		{
			_properyService = properyService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await _properyService.GetSpecialOfferPropertiesList());
		}
	}
}
