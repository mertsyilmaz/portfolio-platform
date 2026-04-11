using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Architectures
{
    public class CreateArchitectureResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
