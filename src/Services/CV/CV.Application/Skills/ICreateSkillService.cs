using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public interface ICreateSkillService
    {
        Task<CreateSkillResponse> CreateAsync(CreateSkillRequest request);
    }
}
