using Blog.Contracts.Categories;

namespace Blog.Application.Categories
{
    public interface IUpdateCategoryService
    {
        Task<UpdateCategoryResponse> UpdateAsync(Guid id, UpdateCategoryRequest request);
    }
}
