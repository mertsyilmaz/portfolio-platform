using File.Domain.Common;

namespace File.Application.Abstractions.Persistence
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task AddAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(Guid id);

        Task DeleteAsync(TEntity entity);
    }
}
