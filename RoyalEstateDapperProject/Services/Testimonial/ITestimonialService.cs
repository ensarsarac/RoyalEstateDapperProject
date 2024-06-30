using RoyalEstateDapperProject.Dtos.TestimonialDtos;

namespace RoyalEstateDapperProject.Services.Testimonial
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsync(int id);
        Task<GetByIdTestimonialDto> GetByIdTestimonialAsync(int id);
    }
}
