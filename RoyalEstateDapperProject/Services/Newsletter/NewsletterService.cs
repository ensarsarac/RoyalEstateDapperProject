using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.CategoryDtos;
using RoyalEstateDapperProject.Dtos.NewsletterDtos;

namespace RoyalEstateDapperProject.Services.Newsletter
{
	public class NewsletterService : INewsletterService
	{
		private readonly DapperContext _dapperContext;

		public NewsletterService(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public async Task CreateNewsletterAsync(CreateNewsletterDto createNewsletterDto)
		{
			string query = "insert into Newsletter (Email) values (@email)";
			var parameters = new DynamicParameters();
			parameters.Add("@email", createNewsletterDto.Email);
			var connection = _dapperContext.SqlConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task DeleteNewsletterAsync(int id)
		{
			string query = "delete from Newsletter where NewsletterId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			var connection = _dapperContext.SqlConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultNewsletterDto>> GetAllNewsletterAsync()
		{
			string query = "select * from Newsletter";
			var connection = _dapperContext.SqlConnection();
			var values = await connection.QueryAsync<ResultNewsletterDto>(query);
			return values.ToList();
		}

		public async Task<GetByIdNewsletterDto> GetByIdNewsletterAsync(int id)
		{
			string query = "select * from Newsletter where NewsletterId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			var connection = _dapperContext.SqlConnection();
			return await connection.QueryFirstOrDefaultAsync<GetByIdNewsletterDto>(query, parameters);
		}

		public async Task UpdateNewsletterAsync(UpdateNewsletterDto updateNewsletterDto)
		{
			string query = "update Newsletter set Email=@email where NewsletterId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@email", updateNewsletterDto.Email);
			parameters.Add("@id", updateNewsletterDto.NewsletterId);
			var connection = _dapperContext.SqlConnection();
			await connection.ExecuteAsync(query, parameters);
		}
	}
}
