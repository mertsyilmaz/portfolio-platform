using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;
using DomainImageUsageType = Blog.Domain.Enums.ImageUsageType;
using ContractImageUsageType = Blog.Contracts.Enums.ImageUsageType;

namespace Blog.Application.Images
{
    public class UpdateImageService : IUpdateImageService
    {
        private readonly IImageRepository _imageRepository;

        public UpdateImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<UpdateImageResponse?> UpdateAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                return null;

            image.FileId = request.FileId;
            image.UsageType = (DomainImageUsageType)request.UsageType;
            image.DisplayOrder = request.DisplayOrder;

            await _imageRepository.UpdateAsync(image);

            return new UpdateImageResponse
            {
                Id = image.Id,
                PostId = image.PostId,
                FileId = image.FileId,
                UsageType = (ContractImageUsageType)image.UsageType,
                DisplayOrder = image.DisplayOrder
            };
        }
    }
}
