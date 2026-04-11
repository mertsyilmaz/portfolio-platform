using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Categories
{
    public class GetCategoryByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
