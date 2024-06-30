using RoyalEstateDapperProject.Dtos.AgentDtos;

namespace RoyalEstateDapperProject.Services.Agent
{
    public interface IAgentService
    {
        Task<List<ResultAgentDto>> GetAllAgentAsync();
        Task CreateAgentAsync(CreateAgentDto createAgentDto);
        Task UpdateAgentAsync(UpdateAgentDto updateAgentDto);
        Task DeleteAgentAsync(int id);
        Task<GetByIdAgentDto> GetByIdAgentAsync(int id);
    }
}
