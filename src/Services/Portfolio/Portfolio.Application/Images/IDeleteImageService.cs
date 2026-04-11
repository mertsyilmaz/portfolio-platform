using Portfolio.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Images
{
    public interface IDeleteImageService
    {
        Task<DeleteImageResponse?> DeleteAsync(Guid id);

    }
}
