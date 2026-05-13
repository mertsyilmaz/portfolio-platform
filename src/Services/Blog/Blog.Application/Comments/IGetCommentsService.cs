using Blog.Contracts.Comments;

namespace Blog.Application.Comments
{
    public interface IGetCommentsService
    {
        Task<List<GetCommentsResponse>> GetAllAsync();
    }
}
