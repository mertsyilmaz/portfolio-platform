using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Services;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;


namespace Blog.Application.Images
{
    public class UpdateImageService : IUpdateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public UpdateImageService(IImageRepository imageRepository, IFileService fileService, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<UpdateImageResponse> UpdateAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                throw new NotFoundException("Image not found.");

            var fileExists = await _fileService.ExistsAsync(request.FileId);

            if (!fileExists)
                throw new ValidationException("File not found.");

            _mapper.Map(request, image);
            image.UpdatedAt = DateTime.UtcNow;

            await _imageRepository.UpdateAsync(image);

            return _mapper.Map<UpdateImageResponse>(image);
        }
    }
}
