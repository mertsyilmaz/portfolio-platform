using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class SocialLinkRepository : Repository<SocialLink>, ISocialLinkRepository
    {
        public SocialLinkRepository(CvDbContext context) : base(context)
        {
        }

        public override async Task<List<SocialLink>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.DisplayOrder).ToListAsync();
        }
    }
}
