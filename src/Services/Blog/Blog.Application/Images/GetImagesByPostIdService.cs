using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;
using ContractImageUsageType = Blog.Contracts.Enums.ImageUsageType;

namespace Blog.Application.Images
{
    public class GetImagesByPostIdService : IGetImagesByPostIdService
    {
        private readonly IImageRepository _imageRepository;

        public GetImagesByPostIdService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<List<GetImagesResponse>> GetByPostIdAsync(Guid postId)
        {
            var images = await _imageRepository.GetByPostIdAsync(postId);

            return images.Select(x => new GetImagesResponse
            {
                Id = x.Id,
                PostId = x.PostId,
                FileId = x.FileId,
                UsageType = (ContractImageUsageType)x.UsageType,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }
    }
}
