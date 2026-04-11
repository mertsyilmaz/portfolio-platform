using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Images;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
{
    public class CreateImageService : ICreateImageService
    {
        private readonly IImageRepository _imageRepository;

        public CreateImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<CreateImageResponse> CreateAsync(CreateImageRequest request)
        {
            var image = new Image
            {
                Id = Guid.NewGuid(),
                FileId = request.FileId,
                DisplayOrder = request.DisplayOrder,
                IsCover = request.IsCover,
                ProjectId = request.ProjectId
            };

            await _imageRepository.AddAsync(image);

            return new CreateImageResponse
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
