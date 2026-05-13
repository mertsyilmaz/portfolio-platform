using Blog.Domain.Common;

namespace Blog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = null!;

        public List<Post> Posts { get; set; } = new();
    }
}
