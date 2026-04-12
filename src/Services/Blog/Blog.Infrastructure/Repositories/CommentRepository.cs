using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context) : base(context)
        {
        }

        public override async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Comments
                .Where(x => x.PostId == postId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
