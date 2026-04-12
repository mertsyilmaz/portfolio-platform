using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Tags
{
    public class CreateTagResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
