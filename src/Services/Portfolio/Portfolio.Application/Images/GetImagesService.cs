using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
{
    public class GetImagesService : IGetImagesService
    {
        private readonly IImageRepository _imageRepository;

        public GetImagesService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<List<GetImagesResponse>> GetAllAsync()
        {
            var images = await _imageRepository.GetAllAsync();

            return images.Select(x => new GetImagesResponse
            {
                Id = x.Id,
                FileId = x.FileId,
                DisplayOrder = x.DisplayOrder,
                IsCover = x.IsCover,
                ProjectId = x.ProjectId
            }).ToList();
        }
    }
}
