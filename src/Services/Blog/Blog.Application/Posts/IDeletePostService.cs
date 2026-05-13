namespace Blog.Application.Posts
{
    public interface IDeletePostService
    {
        Task DeleteAsync(Guid id);
    }
}
