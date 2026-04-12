using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Posts
{
    public class DeletePostResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
