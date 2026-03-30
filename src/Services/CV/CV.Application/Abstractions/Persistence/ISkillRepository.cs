using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(Guid id);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Skill skill);
    }
}
