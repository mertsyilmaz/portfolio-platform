using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;
using CV.Domain.Entities;

namespace CV.Application.Skills
{
    public class CreateSkillService : ICreateSkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public CreateSkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<CreateSkillResponse> CreateAsync(CreateSkillRequest request)
        {
            var skill = _mapper.Map<Skill>(request);
            await _skillRepository.AddAsync(skill);
            return _mapper.Map<CreateSkillResponse>(skill);
        }
    }
}
