using Identity.Domain.Entities;

namespace Identity.Application.Abstractions.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
