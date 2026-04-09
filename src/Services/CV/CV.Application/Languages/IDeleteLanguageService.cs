using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public interface IDeleteLanguageService
    {
        Task<DeleteLanguageResponse?> DeleteAsync(Guid id);
    }
}
