using RoyalEstateDapperProject.Dtos.LocationDtos;

namespace RoyalEstateDapperProject.Services.Location
{
    public interface ILocationService
    {
        Task<List<ResultLocationDto>> GetAllLocationAsync();
        Task CreateLocationAsync(CreateLocationDto createLocationDto);
        Task UpdateLocationAsync(UpdateLocationDto updateLocationDto);
        Task DeleteLocationAsync(int id);
        Task<GetByIdLocationDto> GetByIdLocationAsync(int id);
    }
}
