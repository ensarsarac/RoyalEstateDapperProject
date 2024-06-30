using RoyalEstateDapperProject.Dtos.FeaturesDtos;

namespace RoyalEstateDapperProject.Services.Features
{
    public interface IFeaturesService
    {
        Task<List<ResultFeaturesDto>> GetAllFeaturesAsync();
        Task CreateFeaturesAsync(CreateFeaturesDto createFeaturesDto);
        Task UpdateFeaturesAsync(UpdateFeaturesDto updateFeaturesDto);
        Task DeleteFeaturesAsync(int id);
        Task<GetByIdFeaturesDto> GetByIdFeaturesAsync(int id);
    }
}
