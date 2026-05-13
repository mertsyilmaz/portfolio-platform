using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Categories
{
    public interface IGetCategoriesService
    {
        Task<List<GetCategoriesResponse>> GetAllAsync();
    }
}
