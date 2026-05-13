using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public interface IGetImagesService
    {
        Task<List<GetImagesResponse>> GetAllAsync();

    }
}
