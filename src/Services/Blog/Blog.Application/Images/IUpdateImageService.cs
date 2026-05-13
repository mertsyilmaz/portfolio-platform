using Blog.Contracts.Images;

namespace Blog.Application.Images
{
    public interface IUpdateImageService
    {
        Task<UpdateImageResponse> UpdateAsync(Guid id, UpdateImageRequest request);
    }
}
