using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface IPersonalInfoRepository
    {
        Task AddAsync(PersonalInfo personalInfo);
        Task<PersonalInfo?> GetAsync();
        Task UpdateAsync(PersonalInfo personalInfo);
        Task DeleteAsync(PersonalInfo personalInfo);
    }
}
