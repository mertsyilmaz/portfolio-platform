using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public interface IGetCommentsService
    {
        Task<List<GetCommentsResponse>> GetAllAsync();
    }
}
