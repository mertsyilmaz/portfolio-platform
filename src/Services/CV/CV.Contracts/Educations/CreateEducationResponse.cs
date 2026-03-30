using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Educations
{
    public class CreateEducationResponse
    {
        public Guid Id { get; set; }

        public string SchoolName { get; set; } = null!;

        public string Department { get; set; } = null!;
    }
}
