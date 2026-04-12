using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;
using Blog.Contracts.Images;
using Blog.Contracts.Posts;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public class GetPostsService : IGetPostsService
    {
        private readonly IPostRepository _postRepository;

        public GetPostsService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<GetPostsResponse>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();

            return posts.Select(x => new GetPostsResponse
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                Title = x.Title,
                Slug = x.Slug,
                Summary = x.Summary,
                IsPublished = x.IsPublished,
                IsFeatured = x.IsFeatured,
                DisplayOrder = x.DisplayOrder,
                CreatedAt = x.CreatedAt,
                PublishedAt = x.PublishedAt,
                CoverImageId = x.CoverImageId,

                Categories = x.Categories.Select(c => new GetCategoriesResponse
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),

                Tags = x.Tags.Select(t => new GetTagsResponse
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList(),

                Images = x.Images.Select(i => new GetImagesResponse
                {
                    Id = i.Id,
                    PostId = i.PostId,
                    FileId = i.FileId,
                    UsageType = (Blog.Contracts.Enums.ImageUsageType)i.UsageType,
                    DisplayOrder = i.DisplayOrder
                }).ToList()
            }).ToList();
        }
    }
}
