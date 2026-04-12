using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetByIdsAsync(List<Guid> ids);
    }
}
