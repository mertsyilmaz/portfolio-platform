using Blog.Application.Abstractions.Persistence;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Entities;

namespace Blog.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly BlogDbContext _context;

        public ImageRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(Guid id)
        {
            return await _context.Images
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Image>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Images
                .Where(x => x.PostId == postId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public async Task UpdateAsync(Image image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    }
}
