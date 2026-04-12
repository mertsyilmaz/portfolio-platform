using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;
using ContractImageUsageType = Blog.Contracts.Enums.ImageUsageType;

namespace Blog.Application.Images
{
    public class GetImageByIdService : IGetImageByIdService
    {
        private readonly IImageRepository _imageRepository;

        public GetImageByIdService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<GetImagesResponse?> GetByIdAsync(Guid id)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                return null;

            return new GetImagesResponse
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
