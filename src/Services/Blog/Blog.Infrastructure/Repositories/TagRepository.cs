using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext _context;

        public TagRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(Guid id)
        {
            return await _context.Tags
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tag>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Tags
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task UpdateAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tag tag)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }
    }
}
