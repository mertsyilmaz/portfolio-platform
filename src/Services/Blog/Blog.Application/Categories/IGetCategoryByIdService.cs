using Blog.Contracts.Categories;

namespace Blog.Application.Categories
{
    public interface IGetCategoryByIdService
    {
        Task<GetCategoriesResponse> GetByIdAsync(Guid id);
    }
}
