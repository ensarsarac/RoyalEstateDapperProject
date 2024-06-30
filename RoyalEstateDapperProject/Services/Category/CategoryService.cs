using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.CategoryDtos;

namespace RoyalEstateDapperProject.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _dapperContext;

        public CategoryService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Categories (CategoryName) values (@categoryname)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryname", createCategoryDto.CategoryName);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "delete from Categories where CategoryId=@categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryid", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "select * from Categories";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "select * from Categories where CategoryId=@categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryid", id);
            var connection = _dapperContext.SqlConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update Categories set CategoryName=@categoryname where CategoryId=@categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryname", updateCategoryDto.CategoryName);
            parameters.Add("@categoryid", updateCategoryDto.CategoryId);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
