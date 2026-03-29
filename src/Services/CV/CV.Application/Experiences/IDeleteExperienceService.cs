using CV.Contracts.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public interface IDeleteExperienceService
    {
        Task<DeleteExperienceResponse?> DeleteAsync(Guid id);
    }
}
