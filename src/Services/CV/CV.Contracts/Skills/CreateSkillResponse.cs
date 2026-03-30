using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Skills
{
    public class CreateSkillResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
    }
}
