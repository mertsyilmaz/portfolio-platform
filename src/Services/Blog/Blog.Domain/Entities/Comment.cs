using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }

        public string Content { get; set; } = null!;

        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }

        public Post Post { get; set; } = null!;
    }
}
