using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using Portfolio.Contracts.Categories;
using Portfolio.Contracts.Images;
using Portfolio.Contracts.Projects;
using Portfolio.Contracts.Technologies;
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
                ProjectUrl = project.ProjectUrl,

                Categories = project.Categories.Select(x => new GetCategoriesResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Technologies = project.Technologies.Select(x => new GetTechnologiesResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Architectures = project.Architectures.Select(x => new GetArchitecturesResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Images = project.Images.Select(x => new GetImagesResponse
                {
                    Id = x.Id,
                    FileId = x.FileId,
                    DisplayOrder = x.DisplayOrder,
                    IsCover = x.IsCover
                }).ToList()
            };
        }
    }
}
