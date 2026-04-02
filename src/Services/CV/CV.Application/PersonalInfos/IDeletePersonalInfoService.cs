using CV.Contracts.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public interface IDeletePersonalInfoService
    {
        Task<DeletePersonalInfoResponse?> DeleteAsync();
    }
}
