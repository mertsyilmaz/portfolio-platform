using Blog.Contracts.Posts;

namespace Blog.Application.Posts
{
    public interface ICreatePostService
    {
        Task<CreatePostResponse> CreateAsync(CreatePostRequest request);
    }
}
