using Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Tag : Entity
    {
        public string Name { get; set; } = null!;
        public List<Post> Posts { get; set; } = new();
    }
}
