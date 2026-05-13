using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Rules;
using Portfolio.Contracts.Projects;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Projects
{
    public class CreateProjectService : ICreateProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IPortfolioReferenceValidationService _referenceValidationService;

        public CreateProjectService(
            IProjectRepository projectRepository,
            IMapper mapper,
            IPortfolioReferenceValidationService referenceValidationService)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request)
        {
            var categories = await _referenceValidationService.GetRequiredCategoriesAsync(request.CategoryIds);
            var technologies = await _referenceValidationService.GetRequiredTechnologiesAsync(request.TechnologyIds);
            var architectures = await _referenceValidationService.GetRequiredArchitecturesAsync(request.ArchitectureIds);

            var project = _mapper.Map<Project>(request);
            project.Categories = categories;
            project.Technologies = technologies;
            project.Architectures = architectures;

            await _projectRepository.AddAsync(project);

            return _mapper.Map<CreateProjectResponse>(project);
        }
    }
}
