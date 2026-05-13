namespace Blog.Contracts.Comments
{
    public class CreateCommentRequest
    {
        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }
        public string Content { get; set; } = null!;
    }
}
