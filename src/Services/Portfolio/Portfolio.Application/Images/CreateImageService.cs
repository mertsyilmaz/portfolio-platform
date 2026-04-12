using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Services;
using Portfolio.Contracts.Images;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
{
    public class CreateImageService : ICreateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IFileService _fileService;

        public CreateImageService(IImageRepository imageRepository, IProjectRepository projectRepository, IFileService fileService)
        {
            _imageRepository = imageRepository;
            _projectRepository = projectRepository;
            _fileService = fileService;
        }

        public async Task<CreateImageResponse> CreateAsync(CreateImageRequest request)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);

            if (project == null)
                throw new Exception("Project not found.");

            var fileExists = await _fileService.ExistsAsync(request.FileId);
            if (!fileExists)
                throw new Exception("File not found.");

            var image = new Image
            {
                Id = Guid.NewGuid(),
                FileId = request.FileId,
                DisplayOrder = request.DisplayOrder,
                IsCover = request.IsCover,
                ProjectId = request.ProjectId
            };

            await _imageRepository.AddAsync(image);

            return new CreateImageResponse
            {
                Id = image.Id,
                FileId = image.FileId,
                DisplayOrder = image.DisplayOrder,
                IsCover = image.IsCover,
                ProjectId = image.ProjectId
            };
        }
    }

}
