using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface ISocialLinkRepository
    {
        Task AddAsync(SocialLink socialLink);

        Task<List<SocialLink>> GetAllAsync();

        Task<SocialLink?> GetByIdAsync(Guid id);

        Task UpdateAsync(SocialLink socialLink);

        Task DeleteAsync(SocialLink socialLink);
    }
}
