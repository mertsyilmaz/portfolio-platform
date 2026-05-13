using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public interface ICreateExperienceService
    {
        Task<CreateExperienceResponse> CreateAsync(CreateExperienceRequest request);
    }
}
