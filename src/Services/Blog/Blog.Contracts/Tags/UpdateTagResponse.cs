namespace Blog.Contracts.Tags
{
    public class UpdateTagResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
