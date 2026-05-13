using Blog.Contracts.Images;

namespace Blog.Application.Images
{
    public interface ICreateImageService
    {
        Task<CreateImageResponse> CreateAsync(CreateImageRequest request);
    }
}
