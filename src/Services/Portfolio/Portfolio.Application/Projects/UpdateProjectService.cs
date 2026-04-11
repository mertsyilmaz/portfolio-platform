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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IArchitectureRepository _architectureRepository;

        public UpdateProjectService(IProjectRepository repository, ICategoryRepository categoryRepository, ITechnologyRepository technologyRepository, IArchitectureRepository architectureRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _technologyRepository = technologyRepository;
            _architectureRepository = architectureRepository;
        }

        public async Task<UpdateProjectResponse?> UpdateAsync(Guid id, UpdateProjectRequest request)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null) 
                return null;

            var categories = await _categoryRepository.GetByIdsAsync(request.CategoryIds);
            var technologies = await _technologyRepository.GetByIdsAsync(request.TechnologyIds);
            var architectures = await _architectureRepository.GetByIdsAsync(request.ArchitectureIds);


            project.Name = request.Name;
            project.Description = request.Description;
            project.Summary = request.Summary;
            project.DisplayOrder = request.DisplayOrder;
            project.GithubUrl = request.GithubUrl;
            project.IsFeatured = request.IsFeatured;
            project.ProjectUrl = request.ProjectUrl;

            project.Categories = categories;
            project.Technologies = technologies;
            project.Architectures = architectures;

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
