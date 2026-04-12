using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(x => x.Categories)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .Include(x => x.Images)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts
                .Include(x => x.Categories)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post?> GetBySlugAsync(string slug)
        {
            return await _context.Posts
                .Include(x => x.Categories)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
