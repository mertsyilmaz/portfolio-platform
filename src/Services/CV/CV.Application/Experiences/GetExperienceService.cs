using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public class GetExperienceService : IGetExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public GetExperienceService(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<List<GetExperienceResponse>> GetAllAsync()
        {
            var experiences = await _experienceRepository.GetAllAsync();
            return _mapper.Map<List<GetExperienceResponse>>(experiences);
        }
    }
}
