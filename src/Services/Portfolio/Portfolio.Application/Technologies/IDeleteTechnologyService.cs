namespace Portfolio.Application.Technologies
{
    public interface IDeleteTechnologyService
    {
        Task DeleteAsync(Guid id);
    }
}
