using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(PortfolioDbContext context) : base(context)
        {
        }

        public override async Task<List<Project>> GetAllAsync()
        {
            return await DbSet
                .Include(x => x.Categories)
                .Include(x => x.Technologies)
                .Include(x => x.Architectures)
                .Include(x => x.Images)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public override async Task<Project?> GetByIdAsync(Guid id)
        {
            return await DbSet
                .Include(x => x.Categories)
                .Include(x => x.Technologies)
                .Include(x => x.Architectures)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
