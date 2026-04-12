using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public interface IGetCommentsByPostIdService
    {
        Task<List<GetCommentsResponse>> GetByPostIdAsync(Guid postId);
    }
}
