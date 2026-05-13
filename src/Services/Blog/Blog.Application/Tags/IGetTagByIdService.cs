using Blog.Contracts.Tags;

namespace Blog.Application.Tags
{
    public interface IGetTagByIdService
    {
        Task<GetTagsResponse> GetByIdAsync(Guid id);
    }
}
