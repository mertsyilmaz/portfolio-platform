namespace Portfolio.Application.Categories
{
    public interface IDeleteCategoryService
    {
        Task DeleteAsync(Guid id);
    }
}
