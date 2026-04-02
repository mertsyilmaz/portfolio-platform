using CV.Contracts.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public interface IUpdatePersonalInfoService
    {
        Task<UpdatePersonalInfoResponse?> UpdateAsync(UpdatePersonalInfoRequest request);
    }
}
