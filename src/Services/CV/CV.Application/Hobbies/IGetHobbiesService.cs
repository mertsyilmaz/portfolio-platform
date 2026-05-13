using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public interface IGetHobbiesService
    {
        Task<List<GetHobbiesResponse>> GetAllAsync();
    }
}
