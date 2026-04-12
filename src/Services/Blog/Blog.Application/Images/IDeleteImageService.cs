using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Images
{
    public interface IDeleteImageService
    {
        Task<DeleteImageResponse?> DeleteAsync(Guid id);
    }
}
