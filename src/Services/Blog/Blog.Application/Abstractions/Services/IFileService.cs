using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> ExistsAsync(Guid fileId);
    }
}
