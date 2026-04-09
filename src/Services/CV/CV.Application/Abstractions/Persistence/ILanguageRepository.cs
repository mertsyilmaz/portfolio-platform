using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface ILanguageRepository
    {
        Task AddAsync(Language language);

        Task<List<Language>> GetAllAsync();

        Task<Language?> GetByIdAsync(Guid id);

        Task UpdateAsync(Language language);

        Task DeleteAsync(Language language);
    }
}
