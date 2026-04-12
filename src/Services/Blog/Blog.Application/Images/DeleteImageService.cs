using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Images
{
    public class DeleteImageService : IDeleteImageService
    {
        private readonly IImageRepository _imageRepository;

        public DeleteImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<DeleteImageResponse?> DeleteAsync(Guid id)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                return null;

            await _imageRepository.DeleteAsync(image);

            return new DeleteImageResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
