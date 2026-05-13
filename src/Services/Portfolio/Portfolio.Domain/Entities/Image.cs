using Portfolio.Domain.Common;

namespace Portfolio.Domain.Entities
{
    public class Image : Entity
    {
        public Guid FileId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCover { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
