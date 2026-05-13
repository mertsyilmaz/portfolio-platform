using File.Domain.Entities;

namespace File.Application.Abstractions.Persistence
{
    public interface IFileRepository : IRepository<FileRecord>
    {
    }
}
