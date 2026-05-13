using Blog.Domain.Entities;

namespace Blog.Application.Abstractions.Rules
{
    public interface IBlogReferenceValidationService
    {
        Task<Post> GetRequiredPostAsync(Guid postId);
        Task<List<Category>> GetRequiredCategoriesAsync(List<Guid> categoryIds);
        Task<List<Tag>> GetRequiredTagsAsync(List<Guid> tagIds);
        Task ValidateFileExistsAsync(Guid fileId);
        Task ValidateCoverImageExistsAsync(Guid? coverImageId);
    }
}
