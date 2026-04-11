using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCover { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
