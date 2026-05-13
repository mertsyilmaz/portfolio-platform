using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public interface IGetLanguageByIdService
    {
        Task<GetLanguageByIdResponse> GetByIdAsync(Guid id);
    }
}
