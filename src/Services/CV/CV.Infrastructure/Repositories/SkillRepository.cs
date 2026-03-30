using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly CvDbContext _context;

        public SkillRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skills.OrderBy(x => x.Category).ThenBy(x => x.Name).ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(Guid id)
        {
            return await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }
    }
}
