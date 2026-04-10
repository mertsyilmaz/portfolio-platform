using File.Application.Abstractions.Persistence;
using File.Domain.Entities;
using File.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDbContext _context;

        public FileRepository(FileDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FileRecord fileRecord)
        {
            await _context.Files.AddAsync(fileRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FileRecord>> GetAllAsync()
        {
            return await _context.Files
                .OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<FileRecord?> GetByIdAsync(Guid id)
        {
            return await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(FileRecord fileRecord)
        {
            _context.Files.Remove(fileRecord);
            await _context.SaveChangesAsync();
        }
    }
}
