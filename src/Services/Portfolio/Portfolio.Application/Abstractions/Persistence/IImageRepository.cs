using System;
using System.Collections.Generic;
using System.Text;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Abstractions.Persistence
{
    public interface IImageRepository
    {
        Task AddAsync(Image image);
        Task<List<Image>> GetAllAsync();
        Task<Image?> GetByIdAsync(Guid id);
        Task UpdateAsync(Image image);
        Task DeleteAsync(Image image);
    }
}
