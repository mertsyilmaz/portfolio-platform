using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public interface IGetExperienceByIdService
    {
        Task<GetExperienceByIdResponse> GetByIdAsync(Guid id);
    }
}
