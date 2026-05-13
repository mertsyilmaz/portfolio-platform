using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetByIdsAsync(List<Guid> ids);
    }
}
