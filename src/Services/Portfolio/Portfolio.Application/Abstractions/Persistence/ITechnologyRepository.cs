using Portfolio.Domain.Entities;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface ITechnologyRepository : IRepository<Technology>
    {
        Task<List<Technology>> GetByIdsAsync(List<Guid> ids);
    }
}
