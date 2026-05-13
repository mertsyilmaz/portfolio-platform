using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public interface ICreateArchitectureService
    {
        Task<CreateArchitectureResponse> CreateAsync(CreateArchitectureRequest request);
    }
}
