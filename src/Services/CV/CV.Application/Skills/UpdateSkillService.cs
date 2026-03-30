using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public class UpdateSkillService : IUpdateSkillService
    {
        private readonly ISkillRepository _skillRepository;
        public UpdateSkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<UpdateSkillResponse?> UpdateAsync(Guid id, UpdateSkillRequest request)
        {
            var skill = await _skillRepository.GetByIdAsync(id);

            if(skill == null) 
                return null;

            skill.Name = request.Name;
            skill.Level = request.Level;
            skill.Category = request.Category;

            await _skillRepository.UpdateAsync(skill);

            return new UpdateSkillResponse
            {
                Id = skill.Id,
                Name = request.Name,
                Category = request.Category,
                Level = request.Level
            };
        }
    }
}
