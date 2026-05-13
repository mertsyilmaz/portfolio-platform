using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Rules;
using Blog.Contracts.Images;
using Blog.Domain.Entities;


namespace Blog.Application.Images
{
    public class CreateImageService : ICreateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IBlogReferenceValidationService _referenceValidationService;

        public CreateImageService(
            IImageRepository imageRepository,
            IMapper mapper,
            IBlogReferenceValidationService referenceValidationService)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<CreateImageResponse> CreateAsync(CreateImageRequest request)
        {
            await _referenceValidationService.GetRequiredPostAsync(request.PostId);
            await _referenceValidationService.ValidateFileExistsAsync(request.FileId);

            var image = _mapper.Map<Image>(request);

            await _imageRepository.AddAsync(image);

            return _mapper.Map<CreateImageResponse>(image);
        }
    }
}
