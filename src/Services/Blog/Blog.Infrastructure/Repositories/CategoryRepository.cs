using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext _context;

        public CategoryRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Categories
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
