using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Images
{
    public class DeleteImageResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
