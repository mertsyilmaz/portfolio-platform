using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public class GetSkillsService : IGetSkillsService
    {
        private readonly ISkillRepository _skillRepository;
        public GetSkillsService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<GetSkillsResponse>> GetAllAsync()
        {
            var skills = await _skillRepository.GetAllAsync();

            return skills.Select(x => new GetSkillsResponse
            {
                Id = x.Id,
                Name = x.Name,
                Level = x.Level,
                Category = x.Category
            }).ToList();
        }
    }
}
