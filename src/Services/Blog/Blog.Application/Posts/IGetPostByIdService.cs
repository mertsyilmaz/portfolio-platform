using Blog.Contracts.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public interface IGetPostByIdService
    {
        Task<GetPostByIdResponse> GetByIdAsync(Guid id);
    }
}
