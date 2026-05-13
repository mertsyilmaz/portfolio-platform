using Blog.Contracts.Categories;

namespace Blog.Application.Categories
{
    public interface IGetCategoriesService
    {
        Task<List<GetCategoriesResponse>> GetAllAsync();
    }
}
