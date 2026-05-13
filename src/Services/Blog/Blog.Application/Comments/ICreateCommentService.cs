using Blog.Contracts.Comments;

namespace Blog.Application.Comments
{
    public interface ICreateCommentService
    {
        Task<CreateCommentResponse> CreateAsync(CreateCommentRequest request);
    }
}
