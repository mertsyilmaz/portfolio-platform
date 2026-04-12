using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Comments
{
    public class UpdateCommentRequest
    {
        public string Content { get; set; } = null!;
    }
}
