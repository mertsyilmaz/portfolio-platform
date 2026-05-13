using Blog.Contracts.Comments;

namespace Blog.Application.Comments
{
    public interface IGetCommentByIdService
    {
        Task<GetCommentsResponse> GetByIdAsync(Guid id);
    }
}
