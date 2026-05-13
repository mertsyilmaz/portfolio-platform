namespace CV.Application.Hobbies
{
    public interface IDeleteHobbyService
    {
        Task DeleteAsync(Guid id);
    }
}
