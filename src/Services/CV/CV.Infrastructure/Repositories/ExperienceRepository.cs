using CV.Application.Abstractions.Persistence;
using CV.Domain.Entities;
using CV.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Infrastructure.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly CvDbContext _context;

        public ExperienceRepository(CvDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Experience experience)
        {
            await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync();
        }
    }
}
