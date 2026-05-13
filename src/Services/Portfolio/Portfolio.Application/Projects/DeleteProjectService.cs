using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;

namespace Portfolio.Application.Projects
{
    public class DeleteProjectService : IDeleteProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(project, ErrorMessages.ProjectNotFound);

            await _projectRepository.DeleteAsync(project);
        }
    }
}
