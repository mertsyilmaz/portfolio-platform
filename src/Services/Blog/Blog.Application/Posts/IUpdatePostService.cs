using Blog.Contracts.Posts;

namespace Blog.Application.Posts
{
    public interface IUpdatePostService
    {
        Task<UpdatePostResponse> UpdateAsync(Guid id, UpdatePostRequest request);
    }
}
