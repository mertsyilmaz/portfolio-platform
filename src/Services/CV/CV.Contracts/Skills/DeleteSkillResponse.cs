using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Skills
{
    public class DeleteSkillResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
