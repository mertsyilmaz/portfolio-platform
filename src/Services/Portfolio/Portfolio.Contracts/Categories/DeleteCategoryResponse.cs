using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Categories
{
    public class DeleteCategoryResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
