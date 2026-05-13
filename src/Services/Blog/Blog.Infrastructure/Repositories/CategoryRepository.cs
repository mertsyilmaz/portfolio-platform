using Blog.Application.Abstractions.Persistence;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context) : base(context)
        {
        }

        public override async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Category>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Categories
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }
    }
}
