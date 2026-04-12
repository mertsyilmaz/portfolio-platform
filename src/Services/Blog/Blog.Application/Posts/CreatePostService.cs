using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Posts;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public class CreatePostService : ICreatePostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;

        public CreatePostService(
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public async Task<CreatePostResponse> CreateAsync(CreatePostRequest request)
        {
            var categories = await _categoryRepository.GetByIdsAsync(request.CategoryIds);
            var tags = await _tagRepository.GetByIdsAsync(request.TagIds);

            var post = new Post
            {
                Id = Guid.NewGuid(),
                AuthorId = request.AuthorId,
                Title = request.Title,
                Slug = request.Slug,
                Summary = request.Summary,
                Content = request.Content,
                IsPublished = request.IsPublished,
                IsFeatured = request.IsFeatured,
                DisplayOrder = request.DisplayOrder,
                CreatedAt = DateTime.UtcNow,
                PublishedAt = request.IsPublished ? DateTime.UtcNow : null,
                CoverImageId = request.CoverImageId,

                Categories = categories,
                Tags = tags
            };

            await _postRepository.AddAsync(post);

            return new CreatePostResponse
            {
                Id = post.Id,
                Title = post.Title
            };
        }
    }
}
