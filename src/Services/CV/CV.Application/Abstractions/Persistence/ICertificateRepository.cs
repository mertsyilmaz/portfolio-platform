using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface ICertificateRepository
    {
        Task AddAsync(Certificate certificate);

        Task<List<Certificate>> GetAllAsync();

        Task<Certificate?> GetByIdAsync(Guid id);

        Task UpdateAsync(Certificate certificate);

        Task DeleteAsync(Certificate certificate);
    }
}
