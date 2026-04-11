using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Technologies
{
    public class DeleteTechnologyResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
