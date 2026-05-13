using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Experiences;

namespace CV.Application.Experiences
{
    public class UpdateExperienceService : IUpdateExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public UpdateExperienceService(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<UpdateExperienceResponse> UpdateAsync(Guid id, UpdateExperienceRequest request)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(experience, ErrorMessages.ExperienceNotFound);

            _mapper.Map(request, experience);
            await _experienceRepository.UpdateAsync(experience);

            return _mapper.Map<UpdateExperienceResponse>(experience);
        }
    }
}
