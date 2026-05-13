namespace CV.Application.Educations
{
    public interface IDeleteEducationService
    {
        Task DeleteAsync(Guid id);
    }
}
