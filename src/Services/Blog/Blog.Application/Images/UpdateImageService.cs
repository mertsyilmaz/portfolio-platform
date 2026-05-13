using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Rules;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Images;


namespace Blog.Application.Images
{
    public class UpdateImageService : IUpdateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IBlogReferenceValidationService _referenceValidationService;
        private readonly IMapper _mapper;

        public UpdateImageService(IImageRepository imageRepository, IMapper mapper, IBlogReferenceValidationService referenceValidationService)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<UpdateImageResponse> UpdateAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(image, ErrorMessages.ImageNotFound);

            await _referenceValidationService.ValidateFileExistsAsync(request.FileId);

            _mapper.Map(request, image);

            await _imageRepository.UpdateAsync(image);

            return _mapper.Map<UpdateImageResponse>(image);
        }
    }
}
