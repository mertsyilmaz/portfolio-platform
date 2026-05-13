using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Rules;
using Portfolio.Contracts.Images;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Images
{
    public class CreateImageService : ICreateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IPortfolioReferenceValidationService _referenceValidationService;

        public CreateImageService(
            IImageRepository imageRepository,
            IMapper mapper,
            IPortfolioReferenceValidationService referenceValidationService)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<CreateImageResponse> CreateAsync(CreateImageRequest request)
        {
            await _referenceValidationService.GetRequiredProjectAsync(request.ProjectId);
            await _referenceValidationService.ValidateFileExistsAsync(request.FileId);

            var image = _mapper.Map<Image>(request);
            await _imageRepository.AddAsync(image);

            return _mapper.Map<CreateImageResponse>(image);
        }
    }
}
