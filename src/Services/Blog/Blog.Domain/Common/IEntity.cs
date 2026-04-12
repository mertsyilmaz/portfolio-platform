using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
