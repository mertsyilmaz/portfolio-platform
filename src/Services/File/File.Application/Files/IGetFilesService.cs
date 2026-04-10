using File.Contracts.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Application.Files
{
    public interface IGetFilesService
    {
        Task<List<GetFilesResponse>> GetAllAsync();
    }
}
