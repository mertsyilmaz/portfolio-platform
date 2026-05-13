using Blog.Contracts.Categories;

namespace Blog.Application.Categories
{
    public interface ICreateCategoryService
    {
        Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
    }
}
