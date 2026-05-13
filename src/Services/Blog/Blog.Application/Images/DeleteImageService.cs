using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;

namespace Blog.Application.Images
{
    public class DeleteImageService : IDeleteImageService
    {
        private readonly IImageRepository _imageRepository;

        public DeleteImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(image, ErrorMessages.ImageNotFound);

            await _imageRepository.DeleteAsync(image);

        }
    }
}
