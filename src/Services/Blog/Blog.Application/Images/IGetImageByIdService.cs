using Blog.Contracts.Images;

namespace Blog.Application.Images
{
    public interface IGetImageByIdService
    {
        Task<GetImagesResponse> GetByIdAsync(Guid id);
    }
}
