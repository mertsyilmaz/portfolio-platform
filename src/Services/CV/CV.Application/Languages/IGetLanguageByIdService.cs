using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public interface IGetLanguageByIdService
    {
        Task<GetLanguageByIdResponse?> GetByIdAsync(Guid id);
    }
}
