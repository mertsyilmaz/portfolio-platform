using CV.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public interface IGetSkillByIdService
    {
        Task<GetSkillByIdResponse?> GetByIdAsync(Guid id);
    }
}
