using Blog.Contracts.Posts;

namespace Blog.Application.Posts
{
    public interface IGetPostsService
    {
        Task<List<GetPostsResponse>> GetAllAsync();
    }
}
