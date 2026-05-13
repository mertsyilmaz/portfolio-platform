using Blog.Contracts.Tags;

namespace Blog.Application.Tags
{
    public interface ICreateTagService
    {
        Task<CreateTagResponse> CreateAsync(CreateTagRequest request);
    }
}
