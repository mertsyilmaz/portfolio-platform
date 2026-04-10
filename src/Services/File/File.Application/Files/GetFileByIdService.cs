using File.Application.Abstractions.Persistence;
using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public class GetFileByIdService : IGetFileByIdService
    {
        private readonly IFileRepository _fileRepository;

        public GetFileByIdService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<GetFileByIdResponse> GetByIdAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);

            if (file is null)
                return null;

            return new GetFileByIdResponse
            {
                Id = file.Id,
                FileName = file.FileName,
                StoredFileName = file.StoredFileName,
                ContentType = file.ContentType,
                Extension = file.Extension,
                Size = file.Size,
                RelativePath = file.RelativePath,
                CreatedAt = file.CreatedAt
            };
        }
    }
}
