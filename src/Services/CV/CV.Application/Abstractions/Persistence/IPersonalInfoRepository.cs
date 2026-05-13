using CV.Domain.Entities;

namespace CV.Application.Abstractions.Persistence
{
    public interface IPersonalInfoRepository : IRepository<PersonalInfo>
    {
        Task<PersonalInfo?> GetAsync();
    }
}
