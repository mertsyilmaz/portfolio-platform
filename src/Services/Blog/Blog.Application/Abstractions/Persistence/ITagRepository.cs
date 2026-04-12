using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetByIdsAsync(List<Guid> ids);
    }
}
