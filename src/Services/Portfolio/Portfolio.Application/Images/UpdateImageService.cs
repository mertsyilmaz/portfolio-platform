using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
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
            image.DisplayOrder = request.DisplayOrder;
            image.IsCover = request.IsCover;
            image.ProjectId = request.ProjectId;

            await _imageRepository.UpdateAsync(image);

            return new UpdateImageResponse
            {
                Id = image.Id,
                FileId = image.FileId,
                DisplayOrder = image.DisplayOrder,
                IsCover = image.IsCover,
                ProjectId = image.ProjectId
            };
        }
    }
}
