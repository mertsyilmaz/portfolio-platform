using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.Skills
{
    public class DeleteSkillService : IDeleteSkillService
    {
        private readonly ISkillRepository _skillRepository;

        public DeleteSkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(skill, ErrorMessages.SkillNotFound);
            await _skillRepository.DeleteAsync(skill);
        }
    }
}
