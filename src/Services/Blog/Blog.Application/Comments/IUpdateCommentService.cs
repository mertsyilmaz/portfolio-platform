using Blog.Contracts.Comments;

namespace Blog.Application.Comments
{
    public interface IUpdateCommentService
    {
        Task<UpdateCommentResponse> UpdateAsync(Guid id, UpdateCommentRequest request);
    }
}
