using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Services;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;
using ContractImageUsageType = Blog.Contracts.Enums.ImageUsageType;
using DomainImageUsageType = Blog.Domain.Enums.ImageUsageType;

namespace Blog.Application.Images
{
    public class UpdateImageService : IUpdateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IFileService _fileService;

        public UpdateImageService(IImageRepository imageRepository, IFileService fileService)
        {
            _imageRepository = imageRepository;
            _fileService = fileService;
        }

        public async Task<UpdateImageResponse?> UpdateAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                return null;

            var fileExists = await _fileService.ExistsAsync(request.FileId);

            if (!fileExists)
                throw new Exception("File not found.");

            image.FileId = request.FileId;
            image.UsageType = (DomainImageUsageType)request.UsageType;
            image.DisplayOrder = request.DisplayOrder;
            image.UpdatedAt = DateTime.UtcNow;

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
