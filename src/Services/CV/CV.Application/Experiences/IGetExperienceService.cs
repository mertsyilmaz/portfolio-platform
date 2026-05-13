using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public interface IGetExperienceService
    {
        Task<List<GetExperienceResponse>> GetAllAsync();
    }
}
