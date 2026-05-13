using Identity.Domain.Common;

namespace Identity.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
