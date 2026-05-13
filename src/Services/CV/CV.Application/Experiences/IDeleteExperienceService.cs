namespace CV.Application.Experiences
{
    public interface IDeleteExperienceService
    {
        Task DeleteAsync(Guid id);
    }
}
