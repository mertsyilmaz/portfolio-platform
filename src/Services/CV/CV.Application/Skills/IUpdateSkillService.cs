using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public interface IUpdateSkillService
    {
        Task<UpdateSkillResponse> UpdateAsync(Guid id, UpdateSkillRequest request);
    }
}
