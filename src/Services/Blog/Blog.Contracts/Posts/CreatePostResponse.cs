using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Posts
{
    public class CreatePostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
