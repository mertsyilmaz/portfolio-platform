using Portfolio.Domain.Entities;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetByIdsAsync(List<Guid> ids);
    }
}
