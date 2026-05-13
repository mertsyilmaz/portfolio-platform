namespace Portfolio.Application.Architectures
{
    public interface IDeleteArchitectureService
    {
        Task DeleteAsync(Guid id);
    }
}
