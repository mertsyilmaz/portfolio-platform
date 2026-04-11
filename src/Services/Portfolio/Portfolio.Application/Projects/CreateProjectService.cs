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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IArchitectureRepository _architectureRepository;

        public CreateProjectService(IProjectRepository repository, ICategoryRepository categoryRepository, ITechnologyRepository technologyRepository, IArchitectureRepository architectureRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _technologyRepository = technologyRepository;
            _architectureRepository = architectureRepository;
        }

        public async Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request)
        {
            var categories = await _categoryRepository.GetByIdsAsync(request.CategoryIds);
            var technologies = await _technologyRepository.GetByIdsAsync(request.TechnologyIds);
            var architectures = await _architectureRepository.GetByIdsAsync(request.ArchitectureIds);

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
                Description = request.Description,

                Categories = categories,
                Technologies = technologies,
                Architectures = architectures
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
