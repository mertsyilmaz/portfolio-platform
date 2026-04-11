using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Technologies
{
    public class GetTechnologyByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
