namespace Portfolio.Application.Projects
{
    public interface IDeleteProjectService
    {
        Task DeleteAsync(Guid id);
    }
}
