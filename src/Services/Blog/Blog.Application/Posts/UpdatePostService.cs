using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Rules;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Posts;

namespace Blog.Application.Posts
{
    public class UpdatePostService : IUpdatePostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IBlogReferenceValidationService _referenceValidationService;

        public UpdatePostService(
            IPostRepository postRepository,
            IMapper mapper,
            IBlogReferenceValidationService referenceValidationService)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<UpdatePostResponse> UpdateAsync(Guid id, UpdatePostRequest request)
        {
            var post = await _postRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(post, ErrorMessages.PostNotFound);

            await _referenceValidationService.ValidateCoverImageExistsAsync(request.CoverImageId);
            var categories = await _referenceValidationService.GetRequiredCategoriesAsync(request.CategoryIds);
            var tags = await _referenceValidationService.GetRequiredTagsAsync(request.TagIds);

            _mapper.Map(request, post);


            if (request.IsPublished && post.PublishedAt == null)
                post.PublishedAt = DateTime.UtcNow;

            if (!request.IsPublished)
                post.PublishedAt = null;

            post.Categories = categories;
            post.Tags = tags;

            await _postRepository.UpdateAsync(post);

            return _mapper.Map<UpdatePostResponse>(post);
        }
    }
}
