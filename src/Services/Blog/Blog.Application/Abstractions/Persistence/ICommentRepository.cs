using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Persistence
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetByPostIdAsync(Guid postId);
    }
}
