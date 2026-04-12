using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Categories
{
    public class UpdateCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
