using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Services;
using Portfolio.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
{
    public class UpdateImageService : IUpdateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IFileService _fileService;

        public UpdateImageService(IImageRepository imageRepository, IProjectRepository projectRepository, IFileService fileService)
        {
            _imageRepository = imageRepository;
            _projectRepository = projectRepository;
            _fileService = fileService;
        }

        public async Task<UpdateImageResponse?> UpdateAsync(Guid id, UpdateImageRequest request)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
                return null;

            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
                throw new Exception("Project not found.");

            var fileExists = await _fileService.ExistsAsync(request.FileId);
            if (!fileExists)
                throw new Exception("File not found.");


            image.FileId = request.FileId;
            image.DisplayOrder = request.DisplayOrder;
            image.IsCover = request.IsCover;
            image.ProjectId = request.ProjectId;

            await _imageRepository.UpdateAsync(image);

            return new UpdateImageResponse
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
