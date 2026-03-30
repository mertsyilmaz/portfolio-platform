using CV.Application.Abstractions.Persistence;
using CV.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public class DeleteSkillService : IDeleteSkillService
    {
        private readonly ISkillRepository _skillRepository;
        public DeleteSkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<DeleteSkillResponse?> DeleteAsync(Guid id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);

            if(skill == null) 
                return null;

            await _skillRepository.DeleteAsync(skill);

            return new DeleteSkillResponse
            {
                Id = id,
                IsDeleted = true,
            };
        }
    }
}
