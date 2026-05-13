using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Rules;
using Portfolio.Application.Abstractions.Services;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Rules
{
    public class PortfolioReferenceValidationService : IPortfolioReferenceValidationService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IArchitectureRepository _architectureRepository;
        private readonly IFileService _fileService;

        public PortfolioReferenceValidationService(
            IProjectRepository projectRepository,
            ICategoryRepository categoryRepository,
            ITechnologyRepository technologyRepository,
            IArchitectureRepository architectureRepository,
            IFileService fileService)
        {
            _projectRepository = projectRepository;
            _categoryRepository = categoryRepository;
            _technologyRepository = technologyRepository;
            _architectureRepository = architectureRepository;
            _fileService = fileService;
        }

        public async Task<Project> GetRequiredProjectAsync(Guid projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            Guard.AgainstNotFound(project, ErrorMessages.ProjectNotFound);
            return project!;
        }

        public async Task<List<Category>> GetRequiredCategoriesAsync(List<Guid> categoryIds)
        {
            var categories = await _categoryRepository.GetByIdsAsync(categoryIds);
            Guard.AgainstInvalidIds(categoryIds.Count, categories.Count, ErrorMessages.InvalidCategoryIds);
            return categories;
        }

        public async Task<List<Technology>> GetRequiredTechnologiesAsync(List<Guid> technologyIds)
        {
            var technologies = await _technologyRepository.GetByIdsAsync(technologyIds);
            Guard.AgainstInvalidIds(technologyIds.Count, technologies.Count, ErrorMessages.InvalidTechnologyIds);
            return technologies;
        }

        public async Task<List<Architecture>> GetRequiredArchitecturesAsync(List<Guid> architectureIds)
        {
            var architectures = await _architectureRepository.GetByIdsAsync(architectureIds);
            Guard.AgainstInvalidIds(architectureIds.Count, architectures.Count, ErrorMessages.InvalidArchitectureIds);
            return architectures;
        }

        public async Task ValidateFileExistsAsync(Guid fileId)
        {
            var fileExists = await _fileService.ExistsAsync(fileId);
            Guard.AgainstInvalidReference(fileExists, ErrorMessages.FileNotFound);
        }
    }
}
