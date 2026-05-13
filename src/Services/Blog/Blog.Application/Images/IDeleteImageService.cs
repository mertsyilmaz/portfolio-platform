namespace Blog.Application.Images
{
    public interface IDeleteImageService
    {
        Task DeleteAsync(Guid id);
    }
}
