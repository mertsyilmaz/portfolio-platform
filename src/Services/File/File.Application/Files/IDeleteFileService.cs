using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public interface IDeleteFileService
    {
        Task<DeleteFileResponse> DeleteAsync(Guid id);
    }
}
