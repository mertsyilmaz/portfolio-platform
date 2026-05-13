using File.Application.Abstractions.Persistence;
using File.Application.Abstractions.Storage;
using File.Application.Common.Exceptions;

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

        public async Task DeleteAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(file, ErrorMessages.FileNotFound);

            await _fileStorageService.DeleteAsync(file.RelativePath);
            await _fileRepository.DeleteAsync(file);
        }
    }
}
