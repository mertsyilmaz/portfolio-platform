using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.Experiences
{
    public class DeleteExperienceService : IDeleteExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;

        public DeleteExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(experience, ErrorMessages.ExperienceNotFound);
            await _experienceRepository.DeleteAsync(experience);
        }
    }
}
