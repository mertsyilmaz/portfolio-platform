using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Rules;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public class UpdateProjectService : IUpdateProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IPortfolioReferenceValidationService _referenceValidationService;

        public UpdateProjectService(
            IProjectRepository projectRepository,
            IMapper mapper,
            IPortfolioReferenceValidationService referenceValidationService)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<UpdateProjectResponse> UpdateAsync(Guid id, UpdateProjectRequest request)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(project, ErrorMessages.ProjectNotFound);

            var categories = await _referenceValidationService.GetRequiredCategoriesAsync(request.CategoryIds);
            var technologies = await _referenceValidationService.GetRequiredTechnologiesAsync(request.TechnologyIds);
            var architectures = await _referenceValidationService.GetRequiredArchitecturesAsync(request.ArchitectureIds);

            _mapper.Map(request, project);
            project.Categories = categories;
            project.Technologies = technologies;
            project.Architectures = architectures;

            await _projectRepository.UpdateAsync(project);

            return _mapper.Map<UpdateProjectResponse>(project);
        }
    }
}
