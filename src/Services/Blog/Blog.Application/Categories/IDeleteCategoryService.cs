namespace Blog.Application.Categories
{
    public interface IDeleteCategoryService
    {
        Task DeleteAsync(Guid id);
    }
}
