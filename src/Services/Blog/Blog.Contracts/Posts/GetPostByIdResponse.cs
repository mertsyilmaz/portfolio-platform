using Blog.Contracts.Categories;
using Blog.Contracts.Comments;
using Blog.Contracts.Images;
using Blog.Contracts.Tags;

namespace Blog.Contracts.Posts
{
    public class GetPostByIdResponse
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public Guid? CoverImageId { get; set; }

        public List<GetCategoriesResponse> Categories { get; set; } = new();
        public List<GetTagsResponse> Tags { get; set; } = new();
        public List<GetCommentsResponse> Comments { get; set; } = new();
        public List<GetImagesResponse> Images { get; set; } = new();
    }
}
