using RoyalEstateDapperProject.Dtos.PropertyDtos;

namespace RoyalEstateDapperProject.Services.Property
{
    public interface IProperyService
    {
        Task<List<ResultPropertyWithCategoryAndLocationDto>> GetAllPropertyCategoryAndLocationAsync();
        Task<List<ResultPropertyWithCategoryAndLocationDto>> GetAllPropertyByCategoryIdAsync(int categoryId);
        Task CreatePropertyAsync(CreatePropertyDto createPropertyDto);
        Task UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto);
        Task DeletePropertyAsync(int id);
        Task<GetByIdPropertyDto> GetByIdPropertyAsync(int id);
        Task<GetByIdPropertyWithCategoryAndLocationDto> GetByIdPropertyWithIncludeAsync(int id);
        Task<List<ResultLast5PropertyDto>> GetLast5PropertyListAsync();
        Task FeaturePropertiesTrue(int id);
        Task FeaturePropertiesFalse(int id);
        Task<List<ResultRecentPropertiesDto>> GetRecentPropertiesList();
        Task<List<ResultSpecialOfferPropertyDto>> GetSpecialOfferPropertiesList();
        Task<int> GetTestimonialCount();
        Task<int> GetPropertyCount();
        Task<int> GetAgentCount();
        Task<GetMaxCategoryNameDto> GetMaxProperyCategory();
    }
}
