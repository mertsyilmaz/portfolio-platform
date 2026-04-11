using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface ITechnologyRepository
    {
        Task AddAsync(Technology technology);
        Task<List<Technology>> GetAllAsync();
        Task<List<Technology>> GetByIdsAsync(List<Guid> ids);
        Task<Technology?> GetByIdAsync(Guid id);
        Task UpdateAsync(Technology technology);
        Task DeleteAsync(Technology technology);
    }
}
