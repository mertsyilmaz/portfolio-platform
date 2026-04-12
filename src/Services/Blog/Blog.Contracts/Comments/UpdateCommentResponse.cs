using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Comments
{
    public class UpdateCommentResponse
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
