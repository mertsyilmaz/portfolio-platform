using Blog.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Contracts.Images
{
    public class UpdateImageRequest
    {
        public Guid FileId { get; set; }
        public ImageUsageType UsageType { get; set; }
        public int DisplayOrder { get; set; }
    }
}
