using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public interface IUploadFileService
    {
        Task<UploadFileResponse> UploadAsync(Stream fileStream,string fileName,string contentType,long size, string folderName);
    }
}
