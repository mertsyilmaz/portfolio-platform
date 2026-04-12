using Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = null!;

        public List<Post> Posts { get; set; } = new();
    }
}
