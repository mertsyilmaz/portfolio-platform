using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Services;
using Blog.Application.Common.Exceptions;
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
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public UpdatePostService(
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IFileService fileService,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<UpdatePostResponse> UpdateAsync(Guid id, UpdatePostRequest request)
        {
            var post = await _postRepository.GetByIdAsync(id);

            if (post == null)
                throw new NotFoundException("Post not found");

            if (request.CoverImageId.HasValue)
            {
                var fileExists = await _fileService.ExistsAsync(request.CoverImageId.Value);

                if (!fileExists)
                    throw new ValidationException("Cover image not found.");
            }

            var categories = await _categoryRepository.GetByIdsAsync(request.CategoryIds);
            var tags = await _tagRepository.GetByIdsAsync(request.TagIds);

            if (categories.Count != request.CategoryIds.Count)
                throw new ValidationException("One or more category ids are invalid.");

            if (tags.Count != request.TagIds.Count)
                throw new ValidationException("One or more tag ids are invalid.");

            _mapper.Map(request, post);

            post.UpdatedAt = DateTime.UtcNow;

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
