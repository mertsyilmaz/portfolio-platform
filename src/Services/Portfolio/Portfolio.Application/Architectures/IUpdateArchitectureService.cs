using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public interface IUpdateArchitectureService
    {
        Task<UpdateArchitectureResponse> UpdateAsync(Guid id, UpdateArchitectureRequest request);
    }
}
