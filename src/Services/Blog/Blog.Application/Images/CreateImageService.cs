using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Services;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Images;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Blog.Application.Images
{
    public class CreateImageService : ICreateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IPostRepository _postRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public CreateImageService(
            IImageRepository imageRepository,
            IPostRepository postRepository,
            IFileService fileService,
            IMapper mapper)
        {
            _imageRepository = imageRepository;
            _postRepository = postRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<CreateImageResponse> CreateAsync(CreateImageRequest request)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post == null)
                throw new NotFoundException("Post not found.");

            var fileExists = await _fileService.ExistsAsync(request.FileId);

            if (!fileExists)
                throw new ValidationException("File not found.");

            var image = _mapper.Map<Image>(request);
            image.CreatedAt = DateTime.UtcNow;

            await _imageRepository.AddAsync(image);

            return _mapper.Map<CreateImageResponse>(image);
        }
    }
}
