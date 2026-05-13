using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public interface IGetTechnologiesService
    {
        Task<List<GetTechnologiesResponse>> GetAllAsync();
    }
}
