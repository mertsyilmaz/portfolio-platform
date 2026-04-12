using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public interface IUpdateCommentService
    {
        Task<UpdateCommentResponse?> UpdateAsync(Guid id, UpdateCommentRequest request);
    }
}
