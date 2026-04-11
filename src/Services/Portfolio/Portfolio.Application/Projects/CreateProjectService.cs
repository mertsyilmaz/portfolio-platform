using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Projects;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public class CreateProjectService : ICreateProjectService
    {
        private readonly IProjectRepository _repository;

        public CreateProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Summary = request.Summary,
                GithubUrl = request.GithubUrl,
                IsFeatured = request.IsFeatured,
                ProjectUrl = request.ProjectUrl,
                DisplayOrder = request.DisplayOrder,
                CreatedAt = DateTime.UtcNow,
                Description = request.Description
            };

            await _repository.AddAsync(project);

            return new CreateProjectResponse
            {
                Id = project.Id,
                Name = project.Name
            };
        }
    }
}
