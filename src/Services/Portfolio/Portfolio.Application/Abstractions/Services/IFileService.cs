using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> ExistsAsync(Guid fileId);
    }
}
