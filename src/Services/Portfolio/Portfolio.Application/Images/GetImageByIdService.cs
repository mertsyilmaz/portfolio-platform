using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public class GetImageByIdService : IGetImageByIdService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImageByIdService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<GetImageByIdResponse> GetByIdAsync(Guid id)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(image, ErrorMessages.ImageNotFound);

            return _mapper.Map<GetImageByIdResponse>(image);
        }
    }
}
