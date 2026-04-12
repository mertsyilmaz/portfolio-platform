using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Categories
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; } = null!;
    }
}
