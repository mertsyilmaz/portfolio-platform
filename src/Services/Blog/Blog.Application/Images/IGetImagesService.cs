using Blog.Contracts.Images;

namespace Blog.Application.Images
{
    public interface IGetImagesService
    {
        Task<List<GetImagesResponse>> GetAllAsync();
    }
}
