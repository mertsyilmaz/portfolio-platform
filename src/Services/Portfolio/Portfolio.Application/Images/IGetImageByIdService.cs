using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public interface IGetImageByIdService
    {
        Task<GetImageByIdResponse> GetByIdAsync(Guid id);
    }
}
