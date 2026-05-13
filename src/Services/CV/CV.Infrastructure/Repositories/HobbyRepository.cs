using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class HobbyRepository : Repository<Hobby>, IHobbyRepository
    {
        public HobbyRepository(CvDbContext context) : base(context)
        {
        }

        public override async Task<List<Hobby>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
