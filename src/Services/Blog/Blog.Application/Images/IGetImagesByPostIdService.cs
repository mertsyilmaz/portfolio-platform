using Blog.Contracts.Images;

namespace Blog.Application.Images
{
    public interface IGetImagesByPostIdService
    {
        Task<List<GetImagesResponse>> GetByPostIdAsync(Guid postId);
    }
}
