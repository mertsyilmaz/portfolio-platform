using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public interface IGetTechnologiesService
    {
        Task<List<GetTechnologiesResponse>> GetAllAsync();
    }
}
