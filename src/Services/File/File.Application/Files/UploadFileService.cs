using AutoMapper;
using File.Application.Abstractions.Persistence;
using File.Application.Abstractions.Storage;
using File.Application.Common.Constants;
using File.Application.Common.Exceptions;
using File.Contracts.Files;
using File.Domain.Entities;

namespace File.Application.Files
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public UploadFileService(IFileRepository fileRepository, IFileStorageService fileStorageService, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public async Task<UploadFileResponse> UploadAsync(Stream fileStream, string fileName, string contentType, long size, string folderName)
        {
            var extension = Path.GetExtension(fileName);
            var normalizedFolderName = folderName.Trim().ToLowerInvariant();

            Guard.AgainstInvalidInput(string.IsNullOrWhiteSpace(folderName), ErrorMessages.FolderNameIsRequired);
            Guard.AgainstInvalidInput(
                !FileFolderNames.AllowedFolders.Contains(normalizedFolderName),
                ErrorMessages.InvalidFolderName);

            var (storedFileName, relativePath) = await _fileStorageService.SaveAsync(fileStream, fileName, normalizedFolderName);

            var entity = new FileRecord
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                StoredFileName = storedFileName,
                ContentType = contentType,
                Extension = extension,
                Size = size,
                RelativePath = relativePath,
                FolderName = normalizedFolderName
            };

            await _fileRepository.AddAsync(entity);

            return _mapper.Map<UploadFileResponse>(entity);
        }
    }
}
