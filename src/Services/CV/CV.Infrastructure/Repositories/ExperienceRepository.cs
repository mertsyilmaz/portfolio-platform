using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class ExperienceRepository : Repository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(CvDbContext context) : base(context)
        {
        }

        public override async Task<List<Experience>> GetAllAsync()
        {
            return await DbSet.OrderByDescending(x => x.StartDate).ToListAsync();
        }
    }
}
