using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public interface IGetProjectByIdService
    {
        Task<GetProjectByIdResponse> GetByIdAsync(Guid id);
    }
}
