using File.Application.Abstractions.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Infrastructure.Storage
{
    public class DiskFileStorageService : IFileStorageService
    {
        private readonly string _rootPath;

        public DiskFileStorageService()
        {
            _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }
        }

        public Task DeleteAsync(string relativePath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);

            return Task.CompletedTask;
        }

        public async Task<(string StoredFileName, string RelativePath)> SaveAsync(Stream fileStream, string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var storedFileName = $"{Guid.NewGuid()}{extension}";
            var relativePath = Path.Combine("uploads", storedFileName);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using var output = new FileStream(fullPath, FileMode.Create);
            await fileStream.CopyToAsync(output);

            return (storedFileName, relativePath.Replace("\\", "/"));
        }
    }
}
