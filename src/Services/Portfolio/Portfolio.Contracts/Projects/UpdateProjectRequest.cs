namespace Portfolio.Contracts.Projects
{
    public class UpdateProjectRequest
    {
        public string Name { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectUrl { get; set; } = null!;
        public string GithubUrl { get; set; } = null!;
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }

        public List<Guid> CategoryIds { get; set; } = new();
        public List<Guid> TechnologyIds { get; set; } = new();
        public List<Guid> ArchitectureIds { get; set; } = new();
    }
}
