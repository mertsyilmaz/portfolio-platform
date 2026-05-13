namespace File.Application.Abstractions.Storage
{
    public interface IFileStorageService
    {
        Task<(string StoredFileName, string RelativePath)> SaveAsync(Stream fileStream, string fileName, string folderName);

        Task DeleteAsync(string relativePath);
    }
}
