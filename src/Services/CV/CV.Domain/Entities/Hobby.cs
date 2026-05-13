using CV.Domain.Common;

namespace CV.Domain.Entities
{
    public class Hobby : CreatableEntity
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
