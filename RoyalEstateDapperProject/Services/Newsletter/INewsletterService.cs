using RoyalEstateDapperProject.Dtos.NewsletterDtos;

namespace RoyalEstateDapperProject.Services.Newsletter
{
	public interface INewsletterService
	{
		Task<List<ResultNewsletterDto>> GetAllNewsletterAsync();
		Task CreateNewsletterAsync(CreateNewsletterDto createNewsletterDto);
		Task UpdateNewsletterAsync(UpdateNewsletterDto updateNewsletterDto);
		Task DeleteNewsletterAsync(int id);
		Task<GetByIdNewsletterDto> GetByIdNewsletterAsync(int id);
	}
}
