using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(Guid id);
        Task<List<Comment>> GetByPostIdAsync(Guid postId);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(Comment comment);
    }
}
