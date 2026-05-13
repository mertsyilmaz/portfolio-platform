using CV.Domain.Common;

namespace CV.Domain.Entities
{
    public class Skill : CreatableEntity
    {
        public string Name { get; set; } = null!;

        public string Level { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
