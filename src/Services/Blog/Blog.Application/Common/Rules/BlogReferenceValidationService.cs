using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Rules;
using Blog.Application.Abstractions.Services;
using Blog.Application.Common.Exceptions;
using Blog.Domain.Entities;

namespace Blog.Application.Common.Rules
{
    public class BlogReferenceValidationService : IBlogReferenceValidationService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IFileService _fileService;

        public BlogReferenceValidationService(
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IFileService fileService)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _fileService = fileService;
        }

        public async Task<Post> GetRequiredPostAsync(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            Guard.AgainstNotFound(post, ErrorMessages.PostNotFound);
            return post!;
        }

        public async Task<List<Category>> GetRequiredCategoriesAsync(List<Guid> categoryIds)
        {
            var categories = await _categoryRepository.GetByIdsAsync(categoryIds);
            Guard.AgainstInvalidIds(categoryIds.Count, categories.Count, ErrorMessages.InvalidCategoryIds);
            return categories;
        }

        public async Task<List<Tag>> GetRequiredTagsAsync(List<Guid> tagIds)
        {
            var tags = await _tagRepository.GetByIdsAsync(tagIds);
            Guard.AgainstInvalidIds(tagIds.Count, tags.Count, ErrorMessages.InvalidTagIds);
            return tags;
        }

        public async Task ValidateFileExistsAsync(Guid fileId)
        {
            var fileExists = await _fileService.ExistsAsync(fileId);
            Guard.AgainstInvalidReference(fileExists, ErrorMessages.FileNotFound);
        }

        public async Task ValidateCoverImageExistsAsync(Guid? coverImageId)
        {
            if (!coverImageId.HasValue)
                return;

            var fileExists = await _fileService.ExistsAsync(coverImageId.Value);
            Guard.AgainstInvalidReference(fileExists, ErrorMessages.CoverImageNotFound);
        }
    }
}
