using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public interface IUpdateTechnologyService
    {
        Task<UpdateTechnologyResponse?> UpdateAsync(Guid id, UpdateTechnologyRequest request);
    }
}
