using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public interface IUpdateTagService
    {
        Task<UpdateTagResponse> UpdateAsync(Guid id, UpdateTagRequest request);
    }
}
