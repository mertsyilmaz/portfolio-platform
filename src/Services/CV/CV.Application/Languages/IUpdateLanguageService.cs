using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public interface IUpdateLanguageService
    {
        Task<UpdateLanguageResponse> UpdateAsync(Guid id, UpdateLanguageRequest request);
    }
}
