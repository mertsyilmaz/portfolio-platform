using File.Contracts.Files;

namespace File.Application.Files
{
    public interface IGetFileByIdService
    {
        Task<GetFileByIdResponse> GetByIdAsync(Guid id);
    }
}
