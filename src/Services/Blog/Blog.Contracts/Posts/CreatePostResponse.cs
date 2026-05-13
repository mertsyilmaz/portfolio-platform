namespace Blog.Contracts.Posts
{
    public class CreatePostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
