using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public interface IDeleteTechnologyService
    {
        Task<DeleteTechnologyResponse?> DeleteAsync(Guid id);
    }
}
