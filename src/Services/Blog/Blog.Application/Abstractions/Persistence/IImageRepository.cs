using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Persistence
{
    public interface IImageRepository
    {
        Task AddAsync(Image image);
        Task<List<Image>> GetAllAsync();
        Task<Image?> GetByIdAsync(Guid id);
        Task<List<Image>> GetByPostIdAsync(Guid postId);
        Task UpdateAsync(Image image);
        Task DeleteAsync(Image image);
    }
}
