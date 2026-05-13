using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;
using CV.Domain.Entities;

namespace CV.Application.Experiences
{
    public class CreateExperienceService : ICreateExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public CreateExperienceService(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<CreateExperienceResponse> CreateAsync(CreateExperienceRequest request)
        {
            var experience = _mapper.Map<Experience>(request);
            await _experienceRepository.AddAsync(experience);
            return _mapper.Map<CreateExperienceResponse>(experience);
        }
    }
}
