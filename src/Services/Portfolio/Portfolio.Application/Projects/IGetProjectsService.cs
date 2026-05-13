using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public interface IGetProjectsService
    {
        Task<List<GetProjectsResponse>> GetAllAsync();

    }
}
