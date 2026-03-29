using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public class DeleteExperienceService : IDeleteExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public DeleteExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<DeleteExperienceResponse?> DeleteAsync(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);

            if (experience == null) 
                return null;

            await _experienceRepository.DeleteAsync(experience);

            return new DeleteExperienceResponse
            {
                Id = experience.Id,
                IsDeleted = true
            };
        }
    }
}
