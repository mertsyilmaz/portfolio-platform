using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Images;

namespace Portfolio.Application.Images
{
    public class GetImagesService : IGetImagesService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImagesService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetImagesResponse>> GetAllAsync()
        {
            var images = await _imageRepository.GetAllAsync();
            return _mapper.Map<List<GetImagesResponse>>(images);
        }
    }
}
