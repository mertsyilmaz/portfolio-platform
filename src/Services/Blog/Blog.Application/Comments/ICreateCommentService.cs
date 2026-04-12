using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public interface ICreateCommentService
    {
        Task<CreateCommentResponse> CreateAsync(CreateCommentRequest request);
    }
}
