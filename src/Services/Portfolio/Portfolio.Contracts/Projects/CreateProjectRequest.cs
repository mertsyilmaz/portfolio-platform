using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Portfolio.Contracts.Projects
{
    public class CreateProjectRequest
    {
        public string Name { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectUrl { get; set; } = null!;
        public string GithubUrl { get; set; } = null!;
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }
    }
}
