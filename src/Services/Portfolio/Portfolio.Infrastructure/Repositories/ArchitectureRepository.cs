using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories
{
    public class ArchitectureRepository : Repository<Architecture>, IArchitectureRepository
    {
        public ArchitectureRepository(PortfolioDbContext context) : base(context)
        {
        }

        public override async Task<List<Architecture>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<Architecture>> GetByIdsAsync(List<Guid> ids)
        {
            if (ids is null || ids.Count == 0)
                return [];

            return await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
