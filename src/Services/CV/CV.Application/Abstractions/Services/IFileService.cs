namespace CV.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> ExistsAsync(Guid fileId);
    }
}
