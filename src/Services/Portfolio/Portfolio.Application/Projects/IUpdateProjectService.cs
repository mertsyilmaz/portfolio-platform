using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public interface IUpdateProjectService
    {
        Task<UpdateProjectResponse> UpdateAsync(Guid id, UpdateProjectRequest request);
    }
}
