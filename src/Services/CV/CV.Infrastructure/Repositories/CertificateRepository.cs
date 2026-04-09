using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly CvDbContext _context;

        public CertificateRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Certificate entity)
        {
            await _context.Certificates.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Certificate>> GetAllAsync()
        {
            return await _context.Certificates.OrderByDescending(x => x.IssuedDate).ToListAsync();
        }

        public async Task<Certificate?> GetByIdAsync(Guid id)
        {
            return await _context.Certificates.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Certificate entity)
        {
            _context.Certificates.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Certificate entity)
        {
            _context.Certificates.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
