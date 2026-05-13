using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Categories
{
    public interface ICreateCategoryService
    {
        Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
    }
}
