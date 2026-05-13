using Blog.Contracts.Tags;

namespace Blog.Application.Tags
{
    public interface IGetTagsService
    {
        Task<List<GetTagsResponse>> GetAllAsync();
    }
}
