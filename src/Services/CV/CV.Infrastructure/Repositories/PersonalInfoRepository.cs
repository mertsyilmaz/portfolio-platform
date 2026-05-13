using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class PersonalInfoRepository : Repository<PersonalInfo>, IPersonalInfoRepository
    {
        public PersonalInfoRepository(CvDbContext context) : base(context)
        {
        }

        public async Task<PersonalInfo?> GetAsync()
        {
            return await DbSet.FirstOrDefaultAsync();
        }
    }
}
