using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public interface ICreateTechnologyService
    {
        Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request);
    }
}
