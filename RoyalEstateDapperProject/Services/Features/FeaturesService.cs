using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.CategoryDtos;
using RoyalEstateDapperProject.Dtos.FeaturesDtos;

namespace RoyalEstateDapperProject.Services.Features
{
    public class FeaturesService : IFeaturesService
    {
        private readonly DapperContext _dapperContext;

        public FeaturesService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateFeaturesAsync(CreateFeaturesDto createFeaturesDto)
        {
            string query = "insert into Features (Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createFeaturesDto.Icon);
            parameters.Add("@title", createFeaturesDto.Title);
            parameters.Add("@description", createFeaturesDto.Description);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteFeaturesAsync(int id)
        {
            string query = "delete from Features where FeaturesId=@featuresid";
            var parameters = new DynamicParameters();
            parameters.Add("@featuresid", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultFeaturesDto>> GetAllFeaturesAsync()
        {
            string query = "select * from Features";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultFeaturesDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdFeaturesDto> GetByIdFeaturesAsync(int id)
        {
            string query = "select * from Features where FeaturesId=@featuresid";
            var parameters = new DynamicParameters();
            parameters.Add("@featuresid", id);
            var connection = _dapperContext.SqlConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdFeaturesDto>(query, parameters);
        }

        public async Task UpdateFeaturesAsync(UpdateFeaturesDto updateFeaturesDto)
        {
            string query = "update Features set Icon=@icon,Title=@title,Description=@description where FeaturesId=@featuresid";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateFeaturesDto.Icon);
            parameters.Add("@title", updateFeaturesDto.Title);
            parameters.Add("@description", updateFeaturesDto.Description);
            parameters.Add("@featuresid", updateFeaturesDto.FeaturesId);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
