using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Categories
{
    public interface IGetCategoryByIdService
    {
        Task<GetCategoryByIdResponse> GetByIdAsync(Guid id);
    }
}
