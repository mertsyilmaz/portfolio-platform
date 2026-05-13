namespace CV.Application.Languages
{
    public interface IDeleteLanguageService
    {
        Task DeleteAsync(Guid id);
    }
}
