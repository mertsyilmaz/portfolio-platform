using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public class GetSkillByIdService : IGetSkillByIdService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public GetSkillByIdService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<GetSkillByIdResponse> GetByIdAsync(Guid id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(skill, ErrorMessages.SkillNotFound);
            return _mapper.Map<GetSkillByIdResponse>(skill);
        }
    }
}
