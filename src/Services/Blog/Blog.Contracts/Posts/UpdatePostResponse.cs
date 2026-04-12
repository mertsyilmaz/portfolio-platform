using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Posts
{
    public class UpdatePostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }
        public Guid? CoverImageId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
