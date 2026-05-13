using File.Contracts.Files;

namespace File.Application.Files
{
    public interface IGetFilesService
    {
        Task<List<GetFilesResponse>> GetAllAsync();
    }
}
