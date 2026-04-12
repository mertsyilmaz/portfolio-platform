using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Categories
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; } = null!;
    }
}
