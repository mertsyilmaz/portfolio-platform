using File.Application.Abstractions.Persistence;
using File.Application.Abstractions.Storage;
using File.Contracts.Files;
using File.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;
        public UploadFileService(IFileRepository fileRepository, IFileStorageService fileStorageService)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<UploadFileResponse> UploadAsync(Stream fileStream, string fileName, string contentType, long size, string folderName)
        {
            var extension = Path.GetExtension(fileName);

            if (string.IsNullOrWhiteSpace(folderName))
                throw new Exception("Folder name is required.");

            var allowedFolders = new[] { "portfolio", "cv", "blog" };

            if (!allowedFolders.Contains(folderName.ToLower()))
                throw new Exception("Invalid folder name.");

            var (storedFileName, relativePath) = await _fileStorageService.SaveAsync(fileStream, fileName, folderName);

            var entity = new FileRecord
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                StoredFileName = storedFileName,
                ContentType = contentType,
                Extension = extension,
                Size = size,
                RelativePath = relativePath,
                FolderName = folderName,
                CreatedAt = DateTime.UtcNow
            };

            await _fileRepository.AddAsync(entity);

            return new UploadFileResponse
            {
                Id = entity.Id,
                FileName = entity.FileName,
                ContentType = entity.ContentType,
                Size = entity.Size,
                RelativePath = entity.RelativePath,
                FolderName = entity.FolderName
            };

        }
    }
}
