using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface IHobbyRepository
    {
        Task AddAsync(Hobby hobby);

        Task<List<Hobby>> GetAllAsync();

        Task<Hobby?> GetByIdAsync(Guid id);

        Task UpdateAsync(Hobby hobby);

        Task DeleteAsync(Hobby hobby);
    }
}
