using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Categories
{
    public class GetCategoriesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
