using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(CvDbContext context) : base(context)
        {
        }

        public override async Task<List<Skill>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.Category).ThenBy(x => x.Name).ToListAsync();
        }
    }
}
