using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public class CreateSkillService : ICreateSkillService
    {
        private readonly ISkillRepository _skillRepository;
        public CreateSkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<CreateSkillResponse> CreateAsync(CreateSkillRequest request)
        {
            var skill = new Skill
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Level = request.Level,
                Category = request.Category,
                CreatedAt = DateTime.UtcNow
            };

            await _skillRepository.AddAsync(skill);

            return new CreateSkillResponse { 
                Id = skill.Id,
                Name = request.Name,
                Level = skill.Level
            };


        }
    }
}
