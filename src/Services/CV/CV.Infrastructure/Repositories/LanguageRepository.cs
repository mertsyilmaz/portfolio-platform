using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly CvDbContext _context;

        public LanguageRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Language entity)
        {
            await _context.Languages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Language>> GetAllAsync()
        {
            return await _context.Languages.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Language?> GetByIdAsync(Guid id)
        {
            return await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Language entity)
        {
            _context.Languages.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Language entity)
        {
            _context.Languages.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
