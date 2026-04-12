using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Tags
{
    public class DeleteTagResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
