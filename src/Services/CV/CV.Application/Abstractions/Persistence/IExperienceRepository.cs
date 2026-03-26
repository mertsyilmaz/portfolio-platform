using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Persistence
{
    public interface IExperienceRepository
    {
        Task AddAsync(Experience experience);
    }
}
