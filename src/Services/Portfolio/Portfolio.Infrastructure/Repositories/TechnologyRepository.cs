using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly PortfolioDbContext _context;

        public TechnologyRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Technology technology)
        {
            await _context.Technologies.AddAsync(technology);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Technology technology)
        {
            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Technology>> GetAllAsync()
        {
            return await _context.Technologies.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Technology?> GetByIdAsync(Guid id)
        {
            return await _context.Technologies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Technology>> GetByIdsAsync(List<Guid> ids)
        {
            if (ids is null || ids.Count == 0)
                return new List<Technology>();

            return await _context.Technologies
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task UpdateAsync(Technology technology)
        {
            _context.Technologies.Update(technology);
            await _context.SaveChangesAsync();
        }
    }
}
