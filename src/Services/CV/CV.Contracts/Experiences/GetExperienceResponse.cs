using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Experiences
{
    public class GetExperienceResponse
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
