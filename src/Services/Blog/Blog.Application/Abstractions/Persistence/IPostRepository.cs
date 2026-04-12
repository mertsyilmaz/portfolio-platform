using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post?> GetBySlugAsync(string slug);
    }
}
