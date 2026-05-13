using Blog.Contracts.Comments;

namespace Blog.Application.Comments
{
    public interface IGetCommentsByPostIdService
    {
        Task<List<GetCommentsResponse>> GetByPostIdAsync(Guid postId);
    }
}
