using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Architectures
{
    public class DeleteArchitectureResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
