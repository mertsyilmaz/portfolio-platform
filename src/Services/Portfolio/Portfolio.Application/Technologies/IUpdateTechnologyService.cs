using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public interface IUpdateTechnologyService
    {
        Task<UpdateTechnologyResponse> UpdateAsync(Guid id, UpdateTechnologyRequest request);
    }
}
