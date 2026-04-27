using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public interface IDeleteCommentService
    {
        Task<DeleteCommentResponse> DeleteAsync(Guid id);
    }
}
