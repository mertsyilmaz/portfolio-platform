using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        private readonly CvDbContext _context;

        public PersonalInfoRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PersonalInfo personalInfo)
        {
            await _context.PersonalInfos.AddAsync(personalInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PersonalInfo personalInfo)
        {
            _context.PersonalInfos.Remove(personalInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonalInfo?> GetAsync()
        {
            return await _context.PersonalInfos.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(PersonalInfo personalInfo)
        {
            _context.PersonalInfos.Update(personalInfo);
            await _context.SaveChangesAsync();
        }
    }
}
