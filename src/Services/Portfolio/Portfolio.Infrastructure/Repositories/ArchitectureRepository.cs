using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    public class ArchitectureRepository : IArchitectureRepository
    {
        private readonly PortfolioDbContext _context;

        public ArchitectureRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Architecture architecture)
        {
            await _context.Architectures.AddAsync(architecture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Architecture architecture)
        {
            _context.Architectures.Remove(architecture);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Architecture>> GetAllAsync()
        {
            return await _context.Architectures.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Architecture?> GetByIdAsync(Guid id)
        {
            return await _context.Architectures.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Architecture>> GetByIdsAsync(List<Guid> ids)
        {
            if (ids is null || ids.Count == 0)
                return new List<Architecture>();

            return await _context.Architectures
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task UpdateAsync(Architecture architecture)
        {
            _context.Architectures.Update(architecture);
            await _context.SaveChangesAsync();
        }
    }
}
