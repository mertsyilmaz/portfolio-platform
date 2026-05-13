using File.Application.Abstractions.Persistence;
using File.Domain.Entities;
using File.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace File.Infrastructure.Repositories
{
    public class FileRepository : Repository<FileRecord>, IFileRepository
    {
        public FileRepository(FileDbContext context)
            : base(context)
        {
        }

        public override async Task<List<FileRecord>> GetAllAsync()
        {
            return await DbSet
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
