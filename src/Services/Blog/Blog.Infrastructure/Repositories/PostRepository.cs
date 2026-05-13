using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context)
        {
        }

        public override async Task<List<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(x => x.Categories)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .Include(x => x.Images)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public override async Task<Post?> GetByIdAsync(Guid id)
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
    }
}
