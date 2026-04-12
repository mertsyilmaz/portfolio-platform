using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Post> Posts { get; set; } = new();
    }
}
