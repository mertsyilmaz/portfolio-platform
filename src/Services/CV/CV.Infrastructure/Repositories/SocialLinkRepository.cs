using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class SocialLinkRepository : ISocialLinkRepository
    {
        private readonly CvDbContext _context;

        public SocialLinkRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SocialLink socialLink)
        {
            await _context.SocialLinks.AddAsync(socialLink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SocialLink socialLink)
        {
            _context.SocialLinks.Remove(socialLink);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SocialLink>> GetAllAsync()
        {
            return await _context.SocialLinks.OrderBy(x => x.DisplayOrder).ToListAsync();
        }

        public async Task<SocialLink?> GetByIdAsync(Guid id)
        {
            return await _context.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(SocialLink socialLink)
        {
            _context.SocialLinks.Update(socialLink);
            await _context.SaveChangesAsync();
        }
    }
}
