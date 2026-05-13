using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Rules;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public class UpdateImageService : IUpdateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IPortfolioReferenceValidationService _referenceValidationService;

        public UpdateImageService(
            IImageRepository imageRepository,
            IMapper mapper,
            IPortfolioReferenceValidationService referenceValidationService)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<UpdateImageResponse> UpdateAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(image, ErrorMessages.ImageNotFound);

            await _referenceValidationService.GetRequiredProjectAsync(request.ProjectId);
            await _referenceValidationService.ValidateFileExistsAsync(request.FileId);

            _mapper.Map(request, image);
            await _imageRepository.UpdateAsync(image);

            return _mapper.Map<UpdateImageResponse>(image);
        }
    }
}
