using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Experiences
{
    public class CreateExperienceResponse
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;
    }
}
