using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetByPostIdAsync(Guid postId);
    }
}
