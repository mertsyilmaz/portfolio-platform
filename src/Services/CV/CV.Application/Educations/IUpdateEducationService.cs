using CV.Contracts.Educations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public interface IUpdateEducationService
    {
        Task<UpdateEducationResponse?> UpdateAsync(Guid id,UpdateEducationRequest request);
    }
}
