using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;


namespace Blog.Application.Images
{
    public class GetImagesByPostIdService : IGetImagesByPostIdService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImagesByPostIdService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetImagesResponse>> GetByPostIdAsync(Guid postId)
        {
            var images = await _imageRepository.GetByPostIdAsync(postId);

            return _mapper.Map<List<GetImagesResponse>>(images);
        }
    }
}
