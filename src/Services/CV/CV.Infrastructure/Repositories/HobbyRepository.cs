using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly CvDbContext _context;

        public HobbyRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Hobby entity)
        {
            await _context.Hobbies.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Hobby>> GetAllAsync()
        {
            return await _context.Hobbies.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Hobby?> GetByIdAsync(Guid id)
        {
            return await _context.Hobbies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Hobby entity)
        {
            _context.Hobbies.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Hobby entity)
        {
            _context.Hobbies.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
