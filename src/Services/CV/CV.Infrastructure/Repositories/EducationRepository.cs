using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly CvDbContext _context;
        public EducationRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Education education)
        {
            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Education education)
        {
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _context.Educations.OrderByDescending(x => x.StartDate).ToListAsync();
        }

        public async Task<Education?> GetByIdAsync(Guid id)
        {
            return await _context.Educations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Education education)
        {
            _context.Educations.Update(education);
            await _context.SaveChangesAsync();
        }
    }
}
