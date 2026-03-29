using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public class GetExperienceByIdService : IGetExperienceByIdService
    {
        private readonly IExperienceRepository _experienceRepository;
        public GetExperienceByIdService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<GetExperienceByIdResponse?> GetByIdAsync(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);

            if (experience is null)
            {
                return null;
            }

            return new GetExperienceByIdResponse
            {
                Id = experience.Id,
                CompanyName = experience.CompanyName,
                Position = experience.Position,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                Description = experience.Description,
                IsCurrent = experience.IsCurrent,
                CreatedAt = experience.CreatedAt
            };
        }
    }
}
