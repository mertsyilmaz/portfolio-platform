using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Persistence
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post?> GetBySlugAsync(string slug);
    }
}
