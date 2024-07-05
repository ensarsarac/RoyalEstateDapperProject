using RoyalEstateDapperProject.Dtos.RealEstateDataDtos;

namespace RoyalEstateDapperProject.Services.RealEstateData
{
    public interface IRealEstateDataService
    {
        Task<List<ResultRealEstateDataDto>> GetRealEstateList();
        Task<int> SaleCount();
        Task<int> SoldCount();
        Task<int> BuildCount();
        Task<decimal> AvgPrice();
    }
}
