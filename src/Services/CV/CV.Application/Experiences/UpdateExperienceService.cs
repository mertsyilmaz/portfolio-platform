using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public class UpdateExperienceService : IUpdateExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public UpdateExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<UpdateExperienceResponse?> UpdateAsync(Guid id, UpdateExperienceRequest request)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);

            if (experience == null)
                return null;

            experience.CompanyName = request.CompanyName;
            experience.Position = request.Position;
            experience.StartDate = DateTime.SpecifyKind(request.StartDate,DateTimeKind.Utc);
            experience.EndDate = request.EndDate.HasValue ? DateTime.SpecifyKind(request.EndDate.Value, DateTimeKind.Utc) : null;
            experience.Description = request.Description;
            experience.IsCurrent = request.IsCurrent;

            await _experienceRepository.UpdateAsync(experience);

            return new UpdateExperienceResponse
            {
                Id = experience.Id,
                CompanyName = experience.CompanyName,
                Position = request.Position,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Description = request.Description,
                IsCurrent = request.IsCurrent
            };

        }
    }
}
