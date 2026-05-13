namespace Portfolio.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> ExistsAsync(Guid fileId);
    }
}
