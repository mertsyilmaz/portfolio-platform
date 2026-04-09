using CV.Contracts.Hobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Hobbies
{
    public interface IGetHobbiesService
    {
        Task<List<GetHobbiesResponse>> GetAllAsync();
    }
}
