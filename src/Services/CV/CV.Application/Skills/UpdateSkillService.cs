using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public class UpdateSkillService : IUpdateSkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public UpdateSkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSkillResponse> UpdateAsync(Guid id, UpdateSkillRequest request)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(skill, ErrorMessages.SkillNotFound);
            _mapper.Map(request, skill);
            await _skillRepository.UpdateAsync(skill);
            return _mapper.Map<UpdateSkillResponse>(skill);
        }
    }
}
