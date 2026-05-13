using Blog.Domain.Common;
using Blog.Domain.Enums;

namespace Blog.Domain.Entities
{
    public class Image : AuditableEntity
    {
        public Guid PostId { get; set; }
        public Guid FileId { get; set; }
        public ImageUsageType UsageType { get; set; }
        public int DisplayOrder { get; set; }
        public Post Post { get; set; } = null!;
    }
}
