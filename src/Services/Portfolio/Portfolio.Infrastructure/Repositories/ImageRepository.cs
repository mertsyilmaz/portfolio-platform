using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(PortfolioDbContext context) : base(context)
        {
        }

        public override async Task<List<Image>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.DisplayOrder).ToListAsync();
        }
    }
}
