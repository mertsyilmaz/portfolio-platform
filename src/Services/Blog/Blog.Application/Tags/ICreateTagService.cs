using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public interface ICreateTagService
    {
        Task<CreateTagResponse> CreateAsync(CreateTagRequest request);
    }
}
