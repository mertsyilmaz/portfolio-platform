using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public class CreateExperienceService : ICreateExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public CreateExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<CreateExperienceResponse> CreateAsync(CreateExperienceRequest request)
        {
            var experience = new Experience
            {
                Id = Guid.NewGuid(),
                CompanyName = request.CompanyName,
                Position = request.Position,
                StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc),
                EndDate = request.EndDate.HasValue ? DateTime.SpecifyKind(request.EndDate.Value,DateTimeKind.Utc) : null,
                Description = request.Description,
                IsCurrent = request.IsCurrent,
                CreatedAt = DateTime.UtcNow
            };

            await _experienceRepository.AddAsync(experience);

            return new CreateExperienceResponse
            {
                Id = experience.Id,
                CompanyName = experience.CompanyName,
                Position = experience.Position
            };
        }
    }
}
