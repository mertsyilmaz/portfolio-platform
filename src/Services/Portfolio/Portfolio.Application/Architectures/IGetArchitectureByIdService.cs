using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public interface IGetArchitectureByIdService
    {
        Task<GetArchitectureByIdResponse> GetByIdAsync(Guid id);
    }
}
