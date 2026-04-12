using Blog.Contracts.Categories;
using Blog.Contracts.Images;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Posts
{
    public class GetPostsResponse
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public Guid? CoverImageId { get; set; }

        public List<GetCategoriesResponse> Categories { get; set; } = new();
        public List<GetTagsResponse> Tags { get; set; } = new();
        public List<GetImagesResponse> Images { get; set; } = new();
    }
}
