namespace Portfolio.Application.Images
{
    public interface IDeleteImageService
    {
        Task DeleteAsync(Guid id);
    }
}
