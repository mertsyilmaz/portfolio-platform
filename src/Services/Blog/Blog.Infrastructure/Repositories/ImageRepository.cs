using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(BlogDbContext context) : base(context)
        {
        }

        public override async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public async Task<List<Image>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Images
                .Where(x => x.PostId == postId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }
    }
}
