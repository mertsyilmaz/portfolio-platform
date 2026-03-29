using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Experiences
{
    public class DeleteExperienceResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
