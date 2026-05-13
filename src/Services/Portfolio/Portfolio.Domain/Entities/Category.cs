using Portfolio.Domain.Common;

namespace Portfolio.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = null!;

        public List<Project> Projects { get; set; } = new();
    }
}
