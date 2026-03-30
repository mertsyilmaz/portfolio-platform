using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface IEducationRepository
    {
        Task AddAsync(Education education);

        Task<List<Education>> GetAllAsync();

        Task<Education?> GetByIdAsync(Guid id);

        Task UpdateAsync(Education education);

        Task DeleteAsync(Education education);
    }
}
