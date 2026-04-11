using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
{
    public class GetImageByIdService : IGetImageByIdService
    {
        private readonly IImageRepository _imageRepository;

        public GetImageByIdService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<GetImageByIdResponse?> GetByIdAsync(Guid id)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                return null;

            return new GetImageByIdResponse
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
