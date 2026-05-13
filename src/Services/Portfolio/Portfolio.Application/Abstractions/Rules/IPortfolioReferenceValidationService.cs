using Portfolio.Domain.Entities;

namespace Portfolio.Application.Abstractions.Rules
{
    public interface IPortfolioReferenceValidationService
    {
        Task<Project> GetRequiredProjectAsync(Guid projectId);
        Task<List<Category>> GetRequiredCategoriesAsync(List<Guid> categoryIds);
        Task<List<Technology>> GetRequiredTechnologiesAsync(List<Guid> technologyIds);
        Task<List<Architecture>> GetRequiredArchitecturesAsync(List<Guid> architectureIds);
        Task ValidateFileExistsAsync(Guid fileId);
    }
}
