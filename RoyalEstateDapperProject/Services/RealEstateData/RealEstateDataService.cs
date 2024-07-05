using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.RealEstateDataDtos;

namespace RoyalEstateDapperProject.Services.RealEstateData
{
    public class RealEstateDataService : IRealEstateDataService
    {
        private readonly DapperContext _dapperContext;

        public RealEstateDataService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<decimal> AvgPrice()
        {
            string query = "select avg(convert(decimal(10,2),price)) as 'AvgPrice' from real_estate_data";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<int>(query);
            return values.FirstOrDefault();
        }

        public async Task<int> BuildCount()
        {
            string query = "select count(*) from real_estate_data where status = 'ready_to_build'";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<int>(query);
            return values.FirstOrDefault();
        }

        public async Task<List<ResultRealEstateDataDto>> GetRealEstateList()
        
        {
            string query = "select * from real_estate_data";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultRealEstateDataDto>(query);
            return values.ToList();
        }

        public async Task<int> SaleCount()
        {
            string query = "select count(*) from real_estate_data where status = 'for_sale'";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<int>(query);
            return values.FirstOrDefault();
        }

        public async Task<int> SoldCount()
        {
            string query = "select count(*) from real_estate_data where status = 'sold'";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<int>(query);
            return values.FirstOrDefault();
        }
    }
}
