using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ITagRepository
    {
        Task AddAsync(Tag tag);
        Task<List<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(Guid id);
        Task<List<Tag>> GetByIdsAsync(List<Guid> ids);
        Task UpdateAsync(Tag tag);
        Task DeleteAsync(Tag tag);
    }
}
