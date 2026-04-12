using Blog.Contracts.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public interface IGetPostsService
    {
        Task<List<GetPostsResponse>> GetAllAsync();
    }
}
