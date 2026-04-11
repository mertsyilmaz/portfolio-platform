using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using Portfolio.Contracts.Categories;
using Portfolio.Contracts.Images;
using Portfolio.Contracts.Projects;
using Portfolio.Contracts.Technologies;
using Portfolio.Domain.Entities;
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
                ProjectUrl = x.ProjectUrl,

                Categories = x.Categories.Select(x => new GetCategoriesResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Technologies = x.Technologies.Select(x => new GetTechnologiesResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Architectures = x.Architectures.Select(x => new GetArchitecturesResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Images = x.Images.Select(x => new GetImagesResponse
                {
                    Id = x.Id,
                    FileId = x.FileId,
                    DisplayOrder = x.DisplayOrder,
                    IsCover = x.IsCover,
                    ProjectId = x.ProjectId
                }).ToList()

            }).ToList();
        }
    }
}
