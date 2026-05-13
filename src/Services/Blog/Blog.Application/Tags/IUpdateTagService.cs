using Blog.Contracts.Tags;

namespace Blog.Application.Tags
{
    public interface IUpdateTagService
    {
        Task<UpdateTagResponse> UpdateAsync(Guid id, UpdateTagRequest request);
    }
}
