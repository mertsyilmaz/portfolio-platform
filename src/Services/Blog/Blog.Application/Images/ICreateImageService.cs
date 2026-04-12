using Blog.Contracts.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Images
{
    public interface ICreateImageService
    {
        Task<CreateImageResponse> CreateAsync(CreateImageRequest request);
    }
}
