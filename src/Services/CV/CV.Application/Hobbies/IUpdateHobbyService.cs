using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public interface IUpdateHobbyService
    {
        Task<UpdateHobbyResponse> UpdateAsync(Guid id, UpdateHobbyRequest request);
    }
}
