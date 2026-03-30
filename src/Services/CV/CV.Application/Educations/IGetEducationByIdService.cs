using CV.Contracts.Educations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public interface IGetEducationByIdService
    {
        Task<GetEducationByIdResponse?> GetByIdAsync(Guid id);
    }
}
