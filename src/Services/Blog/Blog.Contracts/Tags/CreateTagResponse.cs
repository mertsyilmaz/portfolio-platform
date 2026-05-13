namespace Blog.Contracts.Tags
{
    public class CreateTagResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
