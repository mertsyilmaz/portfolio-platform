using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogDbContext context) : base(context)
        {
        }

        public override async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Tag>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Tags
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }
    }
}
