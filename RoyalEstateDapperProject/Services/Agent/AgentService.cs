using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.AgentDtos;
using RoyalEstateDapperProject.Dtos.CategoryDtos;

namespace RoyalEstateDapperProject.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly DapperContext _dapperContext;

        public AgentService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateAgentAsync(CreateAgentDto createAgentDto)
        {
            string query = "insert into Agent (NameSurname,Description,ImageUrl) values (@namesurname,@description,@imageurl)";
            var parameters = new DynamicParameters();
            parameters.Add("@namesurname", createAgentDto.NameSurname);
            parameters.Add("@description", createAgentDto.Description);
            parameters.Add("@imageurl", createAgentDto.ImageUrl);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAgentAsync(int id)
        {
            string query = "delete from Agent where AgentId=@agentid";
            var parameters = new DynamicParameters();
            parameters.Add("@agentid", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultAgentDto>> GetAllAgentAsync()
        {
            string query = "select * from Agent";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultAgentDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdAgentDto> GetByIdAgentAsync(int id)
        {
            string query = "select * from Agent where AgentId=@agentid";
            var parameters = new DynamicParameters();
            parameters.Add("@agentid", id);
            var connection = _dapperContext.SqlConnection();
            return await connection.QueryFirstOrDefaultAsync<GetByIdAgentDto>(query, parameters);
        }

        public async Task UpdateAgentAsync(UpdateAgentDto updateAgentDto)
        {
            string query = "update Agent set NameSurname=@namesurname,Description=@description,ImageUrl=@imageurl where AgentId=@agentid";
            var parameters = new DynamicParameters();
            parameters.Add("@namesurname", updateAgentDto.NameSurname);
            parameters.Add("@description", updateAgentDto.Description);
            parameters.Add("@agentid", updateAgentDto.AgentId);
            parameters.Add("@imageurl", updateAgentDto.ImageUrl);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
