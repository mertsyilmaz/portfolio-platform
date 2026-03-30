using CV.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Skills
{
    public interface ICreateSkillService
    {
        Task<CreateSkillResponse> CreateAsync(CreateSkillRequest request);
    }
}
