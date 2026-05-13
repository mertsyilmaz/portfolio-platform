namespace Blog.Application.Comments
{
    public interface IDeleteCommentService
    {
        Task DeleteAsync(Guid id);
    }
}
