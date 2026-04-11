using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public class GetProjectsService : IGetProjectsService
    {
        private readonly IProjectRepository _repository;

        public GetProjectsService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProjectsResponse>> GetAllAsync()
        {
            var projects = await _repository.GetAllAsync();

            return projects.Select(x => new GetProjectsResponse { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Summary = x.Summary,
                DisplayOrder = x.DisplayOrder,
                GithubUrl = x.GithubUrl,
                IsFeatured = x.IsFeatured,
                ProjectUrl = x.ProjectUrl
            }).ToList();
        }
    }
}
