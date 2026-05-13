using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public interface ICreateLanguageService
    {
        Task<CreateLanguageResponse> CreateAsync(CreateLanguageRequest request);
    }
}
