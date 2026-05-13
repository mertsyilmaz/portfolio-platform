using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public interface IGetSkillByIdService
    {
        Task<GetSkillByIdResponse> GetByIdAsync(Guid id);
    }
}
