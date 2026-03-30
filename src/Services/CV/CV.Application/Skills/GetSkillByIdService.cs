using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public class GetSkillByIdService : IGetSkillByIdService
    {
        private readonly ISkillRepository _skillRepository;
        public GetSkillByIdService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<GetSkillByIdResponse?> GetByIdAsync(Guid id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);

            if(skill == null)
                return null;

            return new GetSkillByIdResponse
            {
                Id = skill.Id,
                Name = skill.Name,
                Level = skill.Level,
                Category = skill.Category,
                CreatedAt = skill.CreatedAt
            };
        }
    }
}
