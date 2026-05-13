using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public interface IGetHobbyByIdService
    {
        Task<GetHobbyByIdResponse> GetByIdAsync(Guid id);
    }
}
