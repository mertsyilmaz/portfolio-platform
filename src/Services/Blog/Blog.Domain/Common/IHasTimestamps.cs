using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Common
{
    public interface IHasTimestamps
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
