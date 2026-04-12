using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Common
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
