using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.TagCloudDtos;

namespace RoyalEstateDapperProject.Services.Tag
{
    public class TagService:ITagService
    {
        private readonly DapperContext _dapperContext;

        public TagService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateTagAsync(CreateTagDto createTagDto)
        {
            string query = "insert into TagCloud (TagName) values (@Tagname)";
            var parameters = new DynamicParameters();
            parameters.Add("@Tagname", createTagDto.TagName);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTagAsync(int id)
        {
            string query = "delete from TagCloud where TagId=@Tagid";
            var parameters = new DynamicParameters();
            parameters.Add("@Tagid", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTagDto>> GetAllTagAsync()
        {
            string query = "select * from TagCloud";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdTagDto> GetByIdTagAsync(int id)
        {
            string query = "select * from TagCloud where TagId=@Tagid";
            var parameters = new DynamicParameters();
            parameters.Add("@Tagid", id);
            var connection = _dapperContext.SqlConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdTagDto>(query, parameters);
        }

        public async Task UpdateTagAsync(UpdateTagDto updateTagDto)
        {
            string query = "update TagCloud set TagName=@Tagname where TagId=@Tagid";
            var parameters = new DynamicParameters();
            parameters.Add("@Tagname", updateTagDto.TagName);
            parameters.Add("@Tagid", updateTagDto.TagId);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
