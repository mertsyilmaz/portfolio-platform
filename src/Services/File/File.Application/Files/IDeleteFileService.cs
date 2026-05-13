namespace File.Application.Files
{
    public interface IDeleteFileService
    {
        Task DeleteAsync(Guid id);
    }
}
