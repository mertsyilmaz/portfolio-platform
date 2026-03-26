using CV.Contracts.Experiences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Experiences
{
    public interface ICreateExperienceService
    {
        Task<CreateExperienceResponse> CreateAsync(CreateExperienceRequest request);
    }
}
