using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Domain.Entities
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
