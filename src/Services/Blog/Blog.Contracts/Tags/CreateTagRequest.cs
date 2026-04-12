using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Tags
{
    public class CreateTagRequest
    {
        public string Name { get; set; } = null!;
    }
}
