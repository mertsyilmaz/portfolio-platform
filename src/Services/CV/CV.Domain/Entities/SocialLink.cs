using CV.Domain.Common;

namespace CV.Domain.Entities
{
    public class SocialLink : CreatableEntity
    {
        public string Platform { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
