using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;
using DomainImageUsageType = Blog.Domain.Enums.ImageUsageType;
using Blog.Domain.Entities;

namespace Blog.Application.Images
{
    public class CreateImageService : ICreateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IPostRepository _postRepository;

        public CreateImageService(
            IImageRepository imageRepository,
            IPostRepository postRepository)
        {
            _imageRepository = imageRepository;
            _postRepository = postRepository;
        }

        public async Task<CreateImageResponse> CreateAsync(CreateImageRequest request)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post == null)
                throw new Exception("Post not found.");

            var image = new Image
            {
                Id = Guid.NewGuid(),
                PostId = request.PostId,
                FileId = request.FileId,
                UsageType = (DomainImageUsageType)request.UsageType,
                DisplayOrder = request.DisplayOrder
            };

            await _imageRepository.AddAsync(image);

            return new CreateImageResponse
            {
                Id = image.Id,
                PostId = image.PostId,
                FileId = image.FileId,
                UsageType = request.UsageType,
                DisplayOrder = image.DisplayOrder
            };
        }
    }
}
