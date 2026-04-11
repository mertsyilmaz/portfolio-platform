using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Architectures
{
    public class UpdateArchitectureResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
