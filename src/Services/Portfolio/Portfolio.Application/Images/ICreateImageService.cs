using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public interface ICreateImageService
    {
        Task<CreateImageResponse> CreateAsync(CreateImageRequest request);

    }
}
