using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Categories
{
    public interface IUpdateCategoryService
    {
        Task<UpdateCategoryResponse> UpdateAsync(Guid id, UpdateCategoryRequest request);
    }
}
