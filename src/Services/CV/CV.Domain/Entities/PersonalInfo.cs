using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Domain.Entities
{
    public class PersonalInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Location { get; set; } = null!;
        public Guid? ProfileImageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
