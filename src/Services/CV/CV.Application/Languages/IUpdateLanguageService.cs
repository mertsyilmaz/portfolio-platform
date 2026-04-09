using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public interface IUpdateLanguageService
    {
        Task<UpdateLanguageResponse?> UpdateAsync(Guid id,UpdateLanguageRequest request);
    }
}
