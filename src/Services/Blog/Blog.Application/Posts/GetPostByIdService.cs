using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;
using Blog.Contracts.Comments;
using Blog.Contracts.Images;
using Blog.Contracts.Posts;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public class GetPostByIdService : IGetPostByIdService
    {
        private readonly IPostRepository _postRepository;

        public GetPostByIdService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GetPostByIdResponse?> GetByIdAsync(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            if (post == null)
                return null;

            return new GetPostByIdResponse
            {
                Id = post.Id,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Slug = post.Slug,
                Summary = post.Summary,
                Content = post.Content,
                IsPublished = post.IsPublished,
                IsFeatured = post.IsFeatured,
                DisplayOrder = post.DisplayOrder,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                PublishedAt = post.PublishedAt,
                CoverImageId = post.CoverImageId,

                Categories = post.Categories.Select(c => new GetCategoriesResponse
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),

                Tags = post.Tags.Select(t => new GetTagsResponse
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList(),

                Comments = post.Comments.Select(c => new GetCommentsResponse
                {
                    Id = c.Id,
                    PostId = c.PostId,
                    AuthorId = c.AuthorId,
                    Content = c.Content,
                    IsApproved = c.IsApproved,
                    CreatedAt = c.CreatedAt
                }).ToList(),

                Images = post.Images.Select(i => new GetImagesResponse
                {
                    Id = i.Id,
                    PostId = i.PostId,
                    FileId = i.FileId,
                    UsageType = (Blog.Contracts.Enums.ImageUsageType)i.UsageType,
                    DisplayOrder = i.DisplayOrder
                }).ToList()
            };
        }
    }
}
