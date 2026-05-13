using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetByIdsAsync(List<Guid> ids);
    }
}
