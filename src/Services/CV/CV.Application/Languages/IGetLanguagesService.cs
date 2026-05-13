using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public interface IGetLanguagesService
    {
        Task<List<GetLanguagesResponse>> GetAllAsync();
    }
}
