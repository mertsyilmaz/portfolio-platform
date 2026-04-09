using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Hobbies
{
    public class UpdateHobbyRequest
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
