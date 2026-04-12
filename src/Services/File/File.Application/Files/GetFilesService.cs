using File.Application.Abstractions.Persistence;
using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public class GetFilesService : IGetFilesService
    {
        private readonly IFileRepository _fileRepository;

        public GetFilesService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<List<GetFilesResponse>> GetAllAsync()
        {
            var files = await _fileRepository.GetAllAsync();

            return files.Select(x => new GetFilesResponse
            {
                Id = x.Id,
                FileName = x.FileName,
                ContentType = x.ContentType,
                Size = x.Size,
                RelativePath = x.RelativePath,
                FolderName = x.FolderName
            }).ToList();
        }
    }
}
