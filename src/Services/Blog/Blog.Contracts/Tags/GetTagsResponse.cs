namespace Blog.Contracts.Tags
{
    public class GetTagsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
