using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public class GetExperienceService : IGetExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public GetExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<List<GetExperienceResponse>> GetAllAsync()
        {
            var experiences = await _experienceRepository.GetAllAsync();

            return experiences.Select(x => new GetExperienceResponse
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                Position = x.Position,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsCurrent = x.IsCurrent,
            }).ToList();
        }
    }
}
