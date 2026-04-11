using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public interface ICreateArchitectureService
    {
        Task<CreateArchitectureResponse> CreateAsync(CreateArchitectureRequest request);
    }
}
