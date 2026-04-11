using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public interface IGetArchitecturesService
    {
        Task<List<GetArchitecturesResponse>> GetAllAsync();
    }
}
