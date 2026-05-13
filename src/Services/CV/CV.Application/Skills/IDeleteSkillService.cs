namespace CV.Application.Skills
{
    public interface IDeleteSkillService
    {
        Task DeleteAsync(Guid id);
    }
}
