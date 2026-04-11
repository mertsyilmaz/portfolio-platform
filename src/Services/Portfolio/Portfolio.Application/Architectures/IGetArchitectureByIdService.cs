using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public interface IGetArchitectureByIdService
    {
        Task<GetArchitectureByIdResponse> GetByIdAsync(Guid id);
    }
}
