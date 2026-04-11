using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Projects
{
    public class CreateProjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
