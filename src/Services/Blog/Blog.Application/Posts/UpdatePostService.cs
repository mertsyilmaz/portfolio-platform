using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public class UpdatePostService : IUpdatePostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;

        public UpdatePostService(
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public async Task<UpdatePostResponse?> UpdateAsync(Guid id, UpdatePostRequest request)
        {
            var post = await _postRepository.GetByIdAsync(id);

            if (post == null)
                return null;

            var categories = await _categoryRepository.GetByIdsAsync(request.CategoryIds);
            var tags = await _tagRepository.GetByIdsAsync(request.TagIds);

            post.Title = request.Title;
            post.Slug = request.Slug;
            post.Summary = request.Summary;
            post.Content = request.Content;
            post.IsPublished = request.IsPublished;
            post.IsFeatured = request.IsFeatured;
            post.DisplayOrder = request.DisplayOrder;
            post.CoverImageId = request.CoverImageId;
            post.UpdatedAt = DateTime.UtcNow;

            if (request.IsPublished && post.PublishedAt == null)
            {
                post.PublishedAt = DateTime.UtcNow;
            }

            if (!request.IsPublished)
            {
                post.PublishedAt = null;
            }

            post.Categories = categories;
            post.Tags = tags;

            await _postRepository.UpdateAsync(post);

            return new UpdatePostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Slug = post.Slug,
                Summary = post.Summary,
                Content = post.Content,
                IsPublished = post.IsPublished,
                IsFeatured = post.IsFeatured,
                DisplayOrder = post.DisplayOrder,
                CoverImageId = post.CoverImageId,
                UpdatedAt = post.UpdatedAt,
                PublishedAt = post.PublishedAt
            };
        }
    }
}
