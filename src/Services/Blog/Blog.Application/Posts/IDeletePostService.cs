using Blog.Contracts.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public interface IDeletePostService
    {
        Task<DeletePostResponse> DeleteAsync(Guid id);
    }
}
