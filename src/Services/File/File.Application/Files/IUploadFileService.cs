using File.Contracts.Files;

namespace File.Application.Files
{
    public interface IUploadFileService
    {
        Task<UploadFileResponse> UploadAsync(Stream fileStream, string fileName, string contentType, long size, string folderName);
    }
}
