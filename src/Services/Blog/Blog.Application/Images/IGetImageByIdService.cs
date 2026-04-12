using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Images
{
    public interface IGetImageByIdService
    {
        Task<GetImagesResponse?> GetByIdAsync(Guid id);
    }
}
