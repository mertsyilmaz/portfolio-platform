using Portfolio.Contracts.Architectures;
using Portfolio.Contracts.Categories;
using Portfolio.Contracts.Images;
using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Projects
{
    public class GetProjectsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectUrl { get; set; } = null!;
        public string GithubUrl { get; set; } = null!;
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }

        public List<GetCategoriesResponse> Categories { get; set; } = new();
        public List<GetTechnologiesResponse> Technologies { get; set; } = new();
        public List<GetArchitecturesResponse> Architectures { get; set; } = new();
        public List<GetImagesResponse> Images { get; set; } = new();
    }
}
