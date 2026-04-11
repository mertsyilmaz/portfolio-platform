using System;
using System.Collections.Generic;
using System.Text;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface IArchitectureRepository
    {
        Task AddAsync(Architecture architecture);
        Task<List<Architecture>> GetAllAsync();
        Task<List<Architecture>> GetByIdsAsync(List<Guid> ids);
        Task<Architecture?> GetByIdAsync(Guid id);
        Task UpdateAsync(Architecture architecture);
        Task DeleteAsync(Architecture architecture);
    }
}
