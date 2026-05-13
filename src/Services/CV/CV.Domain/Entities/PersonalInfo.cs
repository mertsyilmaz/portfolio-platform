using CV.Domain.Common;

namespace CV.Domain.Entities
{
    public class PersonalInfo : AuditableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Location { get; set; } = null!;
        public Guid? ProfileImageId { get; set; }
    }
}
