using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Comments
{
    public class DeleteCommentResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
