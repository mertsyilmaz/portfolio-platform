namespace Blog.Contracts.Posts
{
    public class UpdatePostRequest
    {
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }
        public Guid? CoverImageId { get; set; }

        public List<Guid> CategoryIds { get; set; } = new();
        public List<Guid> TagIds { get; set; } = new();
    }
}
