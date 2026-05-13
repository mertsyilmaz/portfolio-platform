using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;


namespace Blog.Application.Images
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
