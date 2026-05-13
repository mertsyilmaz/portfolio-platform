using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;

namespace CV.Application.Skills
{
    public class GetSkillsService : IGetSkillsService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public GetSkillsService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSkillsResponse>> GetAllAsync()
        {
            var skills = await _skillRepository.GetAllAsync();
            return _mapper.Map<List<GetSkillsResponse>>(skills);
        }
    }
}
