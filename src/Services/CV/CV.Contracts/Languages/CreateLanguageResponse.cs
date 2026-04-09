using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Languages
{
    public class CreateLanguageResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
    }
}
