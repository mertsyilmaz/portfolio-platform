using File.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Abstractions.Persistence
{
    public interface IFileRepository
    {
        Task AddAsync(FileRecord fileRecord);

        Task<List<FileRecord>> GetAllAsync();

        Task<FileRecord?> GetByIdAsync(Guid id);

        Task DeleteAsync(FileRecord fileRecord);
    }
}
