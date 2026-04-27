using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;


namespace Blog.Application.Images
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

        public async Task<GetImagesResponse> GetByIdAsync(Guid id)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                throw new NotFoundException("Image not found.");

            return _mapper.Map<GetImagesResponse>(image);
        }
    }
}
