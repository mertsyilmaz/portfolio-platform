using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Domain.Entities
{
    public class Hobby
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
