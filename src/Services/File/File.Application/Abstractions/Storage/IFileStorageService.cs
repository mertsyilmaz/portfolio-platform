using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Abstractions.Storage
{
    public interface IFileStorageService
    {
        Task<(string StoredFileName, string RelativePath)> SaveAsync(Stream fileStream,string fileName);

        Task DeleteAsync(string relativePath);
    }
}
