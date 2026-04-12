using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public interface IGetTagsService
    {
        Task<List<GetTagsResponse>> GetAllAsync();
    }
}
