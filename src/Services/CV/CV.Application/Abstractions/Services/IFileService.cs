using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> ExistsAsync(Guid fileId);
    }
}
