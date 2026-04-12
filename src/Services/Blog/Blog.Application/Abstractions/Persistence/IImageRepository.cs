using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Persistence
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<List<Image>> GetByPostIdAsync(Guid postId);
    }
}
