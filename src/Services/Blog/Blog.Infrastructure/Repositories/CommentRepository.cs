using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _context;

        public CommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            return await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Comment>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Comments
                .Where(x => x.PostId == postId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
