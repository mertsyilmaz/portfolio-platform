using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
        Task<List<Category>> GetByIdsAsync(List<Guid> ids);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
