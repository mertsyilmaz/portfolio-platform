using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectUrl { get; set; } = null!;
        public string GithubUrl { get; set; } = null!;
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Category> Categories { get; set; } = new();
        public List<Technology> Technologies { get; set; } = new();
        public List<Architecture> Architectures { get; set; } = new();
        public List<Image> Images { get; set; } = new();
    }
}
