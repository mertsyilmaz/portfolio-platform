using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public class GetProjectByIdService : IGetProjectByIdService
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProjectByIdResponse?> GetByIdAsync(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null)
                return null;

            return new GetProjectByIdResponse
            {
                Id = project.Id,
                Name = project.Name,
                Summary = project.Summary,
                Description = project.Description,
                DisplayOrder = project.DisplayOrder,
                GithubUrl = project.GithubUrl,
                IsFeatured = project.IsFeatured,
                ProjectUrl = project.ProjectUrl
            };
        }
    }
}
