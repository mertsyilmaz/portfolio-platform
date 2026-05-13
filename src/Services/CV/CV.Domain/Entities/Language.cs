using CV.Domain.Common;

namespace CV.Domain.Entities
{
    public class Language : CreatableEntity
    {
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
    }
}
