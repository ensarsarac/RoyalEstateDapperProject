using RoyalEstateDapperProject.Dtos.TagCloudDtos;

namespace RoyalEstateDapperProject.Services.Tag
{
    public interface ITagService
    {
        Task<List<ResultTagDto>> GetAllTagAsync();
        Task CreateTagAsync(CreateTagDto createTagDto);
        Task UpdateTagAsync(UpdateTagDto updateTagDto);
        Task DeleteTagAsync(int id);
        Task<GetByIdTagDto> GetByIdTagAsync(int id);
    }
}
