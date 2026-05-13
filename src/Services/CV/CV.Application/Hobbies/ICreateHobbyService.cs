using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public interface ICreateHobbyService
    {
        Task<CreateHobbyResponse> CreateAsync(CreateHobbyRequest request);
    }
}
