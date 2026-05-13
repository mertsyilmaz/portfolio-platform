using Blog.Domain.Common;

namespace Blog.Domain.Entities
{
    public class Post : AuditableEntity
    {
        public Guid AuthorId { get; set; }

        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;

        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime? PublishedAt { get; set; }

        public Guid? CoverImageId { get; set; }

        public List<Category> Categories { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public List<Image> Images { get; set; } = new();
    }
}
