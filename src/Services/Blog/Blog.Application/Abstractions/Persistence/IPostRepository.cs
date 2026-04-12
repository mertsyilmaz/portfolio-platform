using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(Guid id);
        Task<Post?> GetBySlugAsync(string slug);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
}
