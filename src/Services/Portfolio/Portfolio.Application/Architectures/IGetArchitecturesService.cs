using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public interface IGetArchitecturesService
    {
        Task<List<GetArchitecturesResponse>> GetAllAsync();
    }
}
