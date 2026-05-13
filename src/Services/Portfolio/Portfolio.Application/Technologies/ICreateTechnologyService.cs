using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public interface ICreateTechnologyService
    {
        Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request);
    }
}
