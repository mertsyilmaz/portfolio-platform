namespace Blog.Application.Tags
{
    public interface IDeleteTagService
    {
        Task DeleteAsync(Guid id);
    }
}
