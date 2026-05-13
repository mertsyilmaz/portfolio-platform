using Portfolio.Domain.Entities;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface IArchitectureRepository : IRepository<Architecture>
    {
        Task<List<Architecture>> GetByIdsAsync(List<Guid> ids);
    }
}
