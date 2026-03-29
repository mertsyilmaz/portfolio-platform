using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly CvDbContext _context;

        public ExperienceRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Experience experience)
        {
            await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Experience experience)
        {
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Experience>> GetAllAsync()
        {
            return await _context.Experiences.OrderByDescending(x => x.StartDate).ToListAsync();
        }

        public async Task<Experience?> GetByIdAsync(Guid id)
        {
            return await _context.Experiences.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
            await _context.SaveChangesAsync();
        }
    }
}
