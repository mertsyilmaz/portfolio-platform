using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Architecture
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Project> Projects { get; set; } = new();
    }
}
