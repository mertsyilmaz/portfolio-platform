using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Educations
{
    public class DeleteEducationResponse
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
