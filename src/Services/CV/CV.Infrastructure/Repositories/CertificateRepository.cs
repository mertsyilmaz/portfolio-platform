using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Repositories
{
    public class CertificateRepository : Repository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(CvDbContext context) : base(context)
        {
        }

        public override async Task<List<Certificate>> GetAllAsync()
        {
            return await DbSet.OrderByDescending(x => x.IssuedDate).ToListAsync();
        }
    }
}
