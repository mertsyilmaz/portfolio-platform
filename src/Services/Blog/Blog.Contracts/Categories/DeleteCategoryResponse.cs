using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Categories
{
    public class DeleteCategoryResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
