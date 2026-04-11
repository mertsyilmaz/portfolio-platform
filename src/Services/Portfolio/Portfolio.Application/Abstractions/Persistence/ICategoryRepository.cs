using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetByIdsAsync(List<Guid> ids);
        Task<Category?> GetByIdAsync(Guid id);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
