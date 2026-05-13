using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public interface IGetSkillsService
    {
        Task<List<GetSkillsResponse>> GetAllAsync();
    }
}
