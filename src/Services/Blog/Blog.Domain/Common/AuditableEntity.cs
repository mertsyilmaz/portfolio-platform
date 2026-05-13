namespace Blog.Domain.Common
{
    public abstract class AuditableEntity : Entity, IHasTimestamps
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
