using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Skills
{
    public class UpdateSkillResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
