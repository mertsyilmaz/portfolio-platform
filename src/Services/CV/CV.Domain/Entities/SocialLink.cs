using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Domain.Entities
{
    public class SocialLink
    {
        public Guid Id { get; set; }

        public string Platform { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int DisplayOrder { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
