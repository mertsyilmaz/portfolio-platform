using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public class GetExperienceByIdService : IGetExperienceByIdService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public GetExperienceByIdService(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<GetExperienceByIdResponse> GetByIdAsync(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(experience, ErrorMessages.ExperienceNotFound);
            return _mapper.Map<GetExperienceByIdResponse>(experience);
        }
    }
}
