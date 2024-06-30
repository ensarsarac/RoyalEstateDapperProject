using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.CategoryDtos;
using RoyalEstateDapperProject.Dtos.TestimonialDtos;

namespace RoyalEstateDapperProject.Services.Testimonial
{
    public class TestimonialService : ITestimonialService
    {
        private readonly DapperContext _dapperContext;

        public TestimonialService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            string query = "insert into Testimonial (NameSurname,ImageUrl,Comment,Title) values (@namesurname,@imageurl,@comment,@title)";
            var parameters = new DynamicParameters();
            parameters.Add("@namesurname", createTestimonialDto.NameSurname);
            parameters.Add("@imageurl", createTestimonialDto.ImageUrl);
            parameters.Add("@comment", createTestimonialDto.Comment);
            parameters.Add("@title", createTestimonialDto.Title);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "delete from Testimonial where TestimonialId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "select * from Testimonial";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdTestimonialDto> GetByIdTestimonialAsync(int id)
        {
            string query = "select * from Testimonial where TestimonialId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.SqlConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = "update Testimonial set NameSurname=@namesurname,ImageUrl=@imageurl,Comment=@comment,Title=@title where TestimonialId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@namesurname", updateTestimonialDto.NameSurname);
            parameters.Add("@imageurl", updateTestimonialDto.ImageUrl);
            parameters.Add("@comment", updateTestimonialDto.Comment);
            parameters.Add("@title", updateTestimonialDto.Title);
            parameters.Add("@id", updateTestimonialDto.TestimonialId);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
