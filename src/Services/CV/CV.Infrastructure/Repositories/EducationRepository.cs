using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        public EducationRepository(CvDbContext context) : base(context)
        {
        }

        public override async Task<List<Education>> GetAllAsync()
        {
            return await DbSet.OrderByDescending(x => x.StartDate).ToListAsync();
        }
    }
}
