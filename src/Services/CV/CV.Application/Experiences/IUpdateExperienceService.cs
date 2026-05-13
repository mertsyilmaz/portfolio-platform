using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public interface IUpdateExperienceService
    {
        Task<UpdateExperienceResponse> UpdateAsync(Guid id, UpdateExperienceRequest request);
    }
}
