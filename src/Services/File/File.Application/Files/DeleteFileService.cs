using File.Application.Abstractions.Persistence;
using File.Application.Abstractions.Storage;
using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public class DeleteFileService : IDeleteFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;

        public DeleteFileService(IFileRepository fileRepository, IFileStorageService fileStorageService)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<DeleteFileResponse> DeleteAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);

            if (file is null)
                return null;

            await _fileStorageService.DeleteAsync(file.RelativePath);
            await _fileRepository.DeleteAsync(file);

            return new DeleteFileResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
