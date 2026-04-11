using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly PortfolioDbContext _context;

        public ImageRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images.OrderBy(x => x.DisplayOrder).ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(Guid id)
        {
            return await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Image image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    }
}
