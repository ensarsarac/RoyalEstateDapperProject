using Microsoft.AspNetCore.Mvc;
using RoyalEstateDapperProject.Services.RealEstateData;
using X.PagedList;

namespace RoyalEstateDapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IRealEstateDataService _realEstateDataService;

        public DashboardController(IRealEstateDataService realEstateDataService)
        {
            _realEstateDataService = realEstateDataService;
        }

        public async Task<IActionResult> Index(decimal? minPrice,decimal? maxPrice,int page=1,int pageSize=10)
        {
            ViewBag.salesCount = await _realEstateDataService.SaleCount();
            ViewBag.soldCount = await _realEstateDataService.SoldCount();
            ViewBag.buildCount = await _realEstateDataService.BuildCount();
            ViewBag.avgPrice = await _realEstateDataService.AvgPrice();
            if(!string.IsNullOrEmpty(minPrice.ToString()) && !string.IsNullOrEmpty(maxPrice.ToString()))
            {
                var values = await _realEstateDataService.GetRealEstateListFilter(minPrice,maxPrice);
                var result = values.ToPagedList(page, pageSize);
                return View(result);
            }
            else
            {
                var values = await _realEstateDataService.GetRealEstateList();
                var result = values.ToPagedList(page, pageSize);
                return View(result);
            }
        }
        public async Task<IActionResult> Chart()
        {
            var stateCount = await _realEstateDataService.StateCount();
            return Json(new {list=stateCount});
        }
    }
}
