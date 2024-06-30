using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.CategoryDtos;
using RoyalEstateDapperProject.Dtos.LocationDtos;

namespace RoyalEstateDapperProject.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly DapperContext _dapperContext;

        public LocationService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            string query = "insert into Locations (Location) values (@location)";
            var parameters = new DynamicParameters();
            parameters.Add("@location", createLocationDto.Location);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteLocationAsync(int id)
        {
            string query = "delete from Locations where LocationId=@locationid";
            var parameters = new DynamicParameters();
            parameters.Add("@locationid", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultLocationDto>> GetAllLocationAsync()
        {
            string query = "select * from Locations";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultLocationDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdLocationDto> GetByIdLocationAsync(int id)
        {
            string query = "select * from Locations where LocationId=@locationid";
            var parameters = new DynamicParameters();
            parameters.Add("@locationid", id);
            var connection = _dapperContext.SqlConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query, parameters);
        }

        public async Task UpdateLocationAsync(UpdateLocationDto updateLocationDto)
        {
            string query = "update Locations set Location=@location where LocationId=@locationid";
            var parameters = new DynamicParameters();
            parameters.Add("@location", updateLocationDto.Location);
            parameters.Add("@locationid", updateLocationDto.LocationId);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
