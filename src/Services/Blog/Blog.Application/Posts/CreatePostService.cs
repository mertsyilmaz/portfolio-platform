using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Rules;
using Blog.Contracts.Posts;
using Blog.Domain.Entities;

namespace Blog.Application.Posts
{
    public class CreatePostService : ICreatePostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IBlogReferenceValidationService _referenceValidationService;

        public CreatePostService(
            IPostRepository postRepository,
            IMapper mapper,
            IBlogReferenceValidationService referenceValidationService)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<CreatePostResponse> CreateAsync(CreatePostRequest request)
        {
            var categories = await _referenceValidationService.GetRequiredCategoriesAsync(request.CategoryIds);
            var tags = await _referenceValidationService.GetRequiredTagsAsync(request.TagIds);

            await _referenceValidationService.ValidateCoverImageExistsAsync(request.CoverImageId);

            var post = _mapper.Map<Post>(request);
            post.PublishedAt = request.IsPublished ? DateTime.UtcNow : null;
            post.Categories = categories;
            post.Tags = tags;

            await _postRepository.AddAsync(post);

            return _mapper.Map<CreatePostResponse>(post);
        }
    }
}
