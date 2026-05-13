using Blog.Contracts.Posts;

namespace Blog.Application.Posts
{
    public interface IGetPostByIdService
    {
        Task<GetPostByIdResponse> GetByIdAsync(Guid id);
    }
}
