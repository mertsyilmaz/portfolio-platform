using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public class UpdateProjectService : IUpdateProjectService
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateProjectResponse?> UpdateAsync(Guid id, UpdateProjectRequest request)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null) 
                return null;

            project.Name = request.Name;
            project.Description = request.Description;
            project.Summary = request.Summary;
            project.DisplayOrder = request.DisplayOrder;
            project.GithubUrl = request.GithubUrl;
            project.IsFeatured = request.IsFeatured;
            project.ProjectUrl = request.ProjectUrl;

            await _repository.UpdateAsync(project);

            return new UpdateProjectResponse
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
