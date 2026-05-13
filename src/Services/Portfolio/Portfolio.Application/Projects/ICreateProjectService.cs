using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public interface ICreateProjectService
    {
        Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request);
    }
}
