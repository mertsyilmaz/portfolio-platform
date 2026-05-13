using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public interface IUpdateImageService
    {
        Task<UpdateImageResponse> UpdateAsync(Guid id, UpdateImageRequest request);
    }
}
