using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public interface IGetFileByIdService
    {
        Task<GetFileByIdResponse> GetByIdAsync(Guid id);
    }
}
