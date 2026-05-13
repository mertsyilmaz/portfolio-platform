using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public interface IGetTechnologyByIdService
    {
        Task<GetTechnologyByIdResponse> GetByIdAsync(Guid id);
    }
}
